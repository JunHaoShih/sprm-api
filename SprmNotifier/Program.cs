using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using SprmCommon;
using SprmNotifier;
using SprmNotifier.Filters;
using SprmNotifier.Notifiers;

var builder = WebApplication.CreateBuilder(args);

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
        IndexFormat = $"sprm-notifier-{formattedEnv}-{DateTime.UtcNow:yyyy-MM}"
    })
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
Log.Debug("init main");

try
{
    // NLog: Setup Serilog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseSerilog();

    // Set Autofac
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(cb => cb.RegisterModule(new ServiceModule(builder.Configuration)));

    // Add services to the container.
    builder.Services.AddSignalR()
        .AddHubOptions<NotifierHub>(options =>
        {
            options.AddFilter(typeof(AuthenticationFilter));
        });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc(
            "v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "SPRM Notifier",
                Description = "Service for"
            }
        );
    });

    // Add hosted service
    builder.Services.AddHostedService<NotifyReceiver>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapGet("/Information", () =>
    {
        return new ServiceInformation
        {
            Name = "SprmNotifier",
            Version = "1.0.0"
        };
    })
    .WithName("Information");

    app.MapHub<NotifierHub>("/notifier");

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
