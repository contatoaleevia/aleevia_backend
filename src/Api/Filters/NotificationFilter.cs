using System.Net;
using Api.ApiResponses;
using CrossCutting.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Api.Filters;

public class NotificationFilter(INotificationContext notificationContext) : ActionFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            var apiResponse = ApiProblemDetails.CreateApiProblemDetails(notificationContext.Notifications);
            var responseContent = JsonConvert.SerializeObject(apiResponse);
            await context.HttpContext.Response.WriteAsync(responseContent);
            return;
        }

        await next();
    }
}