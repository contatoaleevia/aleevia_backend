using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Filters;

[UsedImplicitly]
public class AuthorizeCheckOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Check for authorize attribute
        var hasAuthorize = context.MethodInfo.DeclaringType != null && context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>()
            .Any();

        if (!hasAuthorize) return;

        // Get roles from attribute if present
        var attributes = context.MethodInfo.GetCustomAttributes(true)
            .Union(context.MethodInfo.DeclaringType?.GetCustomAttributes(true) ?? [])
            .OfType<AuthorizeAttribute>();

        var roles = attributes
            .Select(attr => attr.Roles)
            .Where(role => !string.IsNullOrEmpty(role))
            .ToList();

        // Add roles information to the description
        if (roles.Count != 0)
        {
            operation.Description += $"\n\n**Roles necessárias**: {string.Join(", ", roles)}";
        }
        else
        {
            operation.Description += "\n\n**Precisa estar autenticado, não tem Role específica**";
        }
    }
}