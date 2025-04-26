using System.Net;
using CrossCutting.Notifications;
using Domain.Exceptions;

namespace Api.ApiResponses;

public class ApiProblemDetails
{
    public string Type { get; private set; }
    public string Title { get; private set; }
    public int StatusCode { get; private set; }
    public List<ApiError> Errors { get; private set; }

    private ApiProblemDetails(
        string type,
        string title,
        Exception error,
        int httpStatusCodeCode)
    {
        Type = type;
        Title = title;
        Errors = CreateError(error);
        StatusCode = httpStatusCodeCode;
    }

    private ApiProblemDetails(
        string title,
        IList<Notification> errors)
    {
        Type = errors.First().Type;
        Title = title;
        StatusCode = (int)HttpStatusCode.BadRequest;
        Errors = CreateNotifications(errors);
    }

    public static ApiProblemDetails CreateApiProblemDetails(ApiException error)
        => new(
            error.GetType().Name,
            "An error occurred",
            error,
            error.StatusCode);
    
    public static ApiProblemDetails CreateApiProblemDetails(Exception error)
        => new(
            error.GetType().Name,
            "An unexpected error occured",
            error,
            500);

    public static ApiProblemDetails CreateApiProblemDetails(IList<Notification> notifications)
        => new("One or more errors occurred", notifications);

    private static List<ApiError> CreateError(Exception error)
    {
        return [new ApiError(error)];
    }

    private static List<ApiError> CreateNotifications(IList<Notification> notifications)
    {
        return notifications.Select(notification => new ApiError(notification)).ToList();
    }
}