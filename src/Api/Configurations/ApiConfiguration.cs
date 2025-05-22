using Api.Middlewares;
using Infrastructure.Contexts;
using Infrastructure.DependencyInjections;

namespace Api.Configurations;

public static class ApiConfiguration
{
    public static void UseApiConfig(this WebApplication app)
    {
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseHsts();
        
        app.UseAuthentication();

        app.UseAuthorization(); 
        
        app.UseMiddleware(typeof(ErrorHandlerMiddleware));

        app.UseSecurityHeaders();
        
        app.MapControllers();
        
        app.MigrateDatabase<ApiDbContext>();
    }
}