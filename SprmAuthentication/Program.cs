using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using SprmAuthentication;
using SprmAuthentication.EFs;
using SprmAuthentication.Settings;
using System.Text.Json;

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
            // TODO ¦Û­qModel Binding ¿ù»~°T®§
        });

    // NLog: Setup Serilog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Information);
    builder.Host.UseSerilog();

    // Set Autofac
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(cb => cb.RegisterModule(new ServiceModule(builder.Configuration)));

    var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>(c => c.BindNonPublicProperties = true)!;
    // Set Entity Framework
    builder.Services.AddDbContext<AuthenticationContext>(opt =>
        opt.UseNpgsql(apiSettings.ConnectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "sprm-auth"))
    );

    var app = builder.Build();

    // Configure the HTTP request pipeline.

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
