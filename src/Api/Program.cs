using Api.Configurations;
using Application.DependencyInjections;
using CrossCutting.DependencyInjections;
using Domain.DependencyInjections;
using Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddApiServices();
builder.Services.AddCrossCuttingServices(configuration);
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseApiConfig();

app.Run();