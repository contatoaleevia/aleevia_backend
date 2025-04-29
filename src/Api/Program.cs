using Api.Configurations;
using Application.DependencyInjections;
using CrossCutting.DependencyInjections;
using Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddCrossCuttingServices();
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddApiServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseApiConfig();

app.Run();