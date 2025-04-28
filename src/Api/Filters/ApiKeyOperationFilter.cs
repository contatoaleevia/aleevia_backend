using Api.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Filters;

public class ApiKeyOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var apiKeyAttributes = context.MethodInfo?
            .GetCustomAttributes(true)
            .OfType<ApiKeyAttribute>()
            .Distinct();

        if (apiKeyAttributes == null || !apiKeyAttributes.Any())
        {
            apiKeyAttributes = context.MethodInfo?.DeclaringType?
                .GetCustomAttributes(true)
                .OfType<ApiKeyAttribute>()
                .Distinct();
                
            if (apiKeyAttributes == null || !apiKeyAttributes.Any())
                return;
        }

        operation.Parameters ??= new List<OpenApiParameter>();
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Api-Key",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema { Type = "string" },
            Description = "API Key Authentication"
        });
    }
}