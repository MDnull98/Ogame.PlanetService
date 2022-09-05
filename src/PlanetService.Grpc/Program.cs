using Microsoft.EntityFrameworkCore;
using PlanetService.BusinessLogic;
using PlanetService.DataAccess;
using PlanetService.Grpc;
using PlanetService.Grpc.Configurations;
using PlanetService.Grpc.Interceptors;
using PlanetService.Grpc.Mapping;
using Services = PlanetService.Grpc.Services;

var builder = WebApplication.CreateBuilder(args)
                            .AddAppSettings()
                            .AddSerilogLogger();

var configuration = builder.Configuration;

builder
    .Services
    .AddGrpc(options =>
    {
        options.Interceptors.Add<ErrorHandlingInterceptor>();
        options.Interceptors.Add<ValidationInterceptor>();
    })
    .Services
    .AddRepositories()
    .AddProviders()
    .AddGrpcClients(configuration)
    .AddServiceClients()
    .AddMemoryCache()
    .AddHealthChecks(configuration)
    .AddAutoMapper(config =>
    {
        config.AddProfile(new MappingProfile());
    })
    .AddPostgreSqlContext(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("PlanetDb"));
    });

var app = builder.Build();

app.UseHealthProbes();

app.MapGrpcHealthChecksService();

app.MapGrpcService<Services.PlanetService>();
app.MapGrpcService<Services.InternalPlanetService>();

app.MapGet("/", () => "Service start!");

app.Run();

namespace PlanetService.Grpc
{
    public partial class Program { }
}
