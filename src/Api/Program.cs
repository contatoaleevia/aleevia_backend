using Api.Configurations;
using Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddApiServices();
// builder.Services.AddApplicationServices();
// builder.Services.AddDomainServices();
builder.Services.AddInfrastructureServices(configuration);

var app = builder.Build();

app.UseApiConfig();

app.Run();