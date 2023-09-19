using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NSwag;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using SprmApi;
using SprmApi.Core.Auth;
using SprmApi.EFs;
using SprmApi.MiddleWares;
using SprmApi.Settings;
using SprmCommon.Error;
using SprmCommon.Response;
using System.Text;
using System.Text.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Get ASPNETCORE_ENVIRONMENT environment variable
string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: true);
builder.Configuration.AddEnvironmentVariables();

string formattedEnv = string.IsNullOrWhiteSpace(env)
    ? "production"
    : env.ToLower().Replace(".", "-");

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"sprm-api-{formattedEnv}-{DateTime.UtcNow:yyyy-MM}"
    })
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
Log.Debug("init main");

try
{

    // Add services to the container.

    builder.Services
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            //自訂Model Binding 錯誤訊息
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState.Keys
                    .SelectMany(key => context.ModelState[key]!.Errors
                    .Select(x =>
                    {
                        if (string.IsNullOrEmpty(x.ErrorMessage))
                            return x.Exception?.Message;
                        else
                            return x.ErrorMessage;
                    }))
                    .ToList();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine(error!.ToString());
                }
                return new BadRequestObjectResult(new GenericResponse<string>
                {
                    Code = ErrorCode.ModelBindingError,
                    Message = ErrorCode.ModelBindingError.GetMessage(),
                    Content = stringBuilder.ToString(),
                });
            };
        });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseSerilog();

    // Set Autofac
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(cb => cb.RegisterModule(new ServiceModule(builder.Configuration)));

    // NSwag
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddOpenApiDocument(settings =>
    {
        settings.Title = "Simple production routing management";
        settings.Version = "1.0.0";
        settings.Description = "Simple production routing management API";
        settings.AddSecurity("Bearer Token", Enumerable.Empty<string>(),
            new OpenApiSecurityScheme()
            {
                Type = OpenApiSecuritySchemeType.Http,
                In = OpenApiSecurityApiKeyLocation.Header,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Put your JWT token here"
            }
        );
    });

    // Add hosted service
    builder.Services.AddHostedService<EnsureAdminHostedService>();

    var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>(c => c.BindNonPublicProperties = true);
    // Set Entity Framework
    builder.Services.AddDbContext<SprmContext>(opt =>
        opt.UseNpgsql(apiSettings.ConnectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "sprm"))
    );

    var app = builder.Build();

    // Entity Framework migrate on startup
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<SprmContext>();
        context.Database.Migrate();
    }

    // Add swagger
    app.UseOpenApi(p => p.Path = "/swagger/{documentName}/swagger.yaml");
    app.UseSwaggerUi3(p => p.DocumentPath = "/swagger/{documentName}/swagger.yaml");
    app.UseReDoc(p =>
    {
        p.Path = "/redoc";
        p.DocumentPath = "/swagger/{documentName}/swagger.yaml";
    });

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseExceptionHandler("/api/Error");
    app.UseWhen(
        httpContext => (
            !httpContext.Request.Path.StartsWithSegments("/api/Authentication") &&
            !httpContext.Request.Path.StartsWithSegments("/api/Error")
        ),
        subApp =>
        {
            subApp.UseHeaderVerify();
            subApp.UsePagination();
        }
    );

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    // NLog: catch setup errors
    Log.Error(e, "API terminated due to exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    Log.CloseAndFlush();
}
