using Api.Configurations;
using Application.DependencyInjections;
using CrossCutting.DependencyInjections;
using Domain.DependencyInjections;
using Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});

builder.Services.AddCrossCuttingServices();
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddDomainServices();
builder.Services.AddApiServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseApiConfig();

app.Run();