using Api.Configurations;
using Application.DependencyInjections;
using CrossCutting.DependencyInjections;
using Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddApiServices();
builder.Services.AddApplicationServices();
builder.Services.AddCrossCuttingServices();
builder.Services.AddInfrastructureServices(configuration);

var app = builder.Build();

app.UseApiConfig();

app.Run();