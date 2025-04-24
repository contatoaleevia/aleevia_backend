﻿using CrossCutting.Notifications;

namespace Api.ApiResponses;

public class ApiError
{
    public string Message { get; private set; }
    public string? StackTrace { get; private set; }
    
    
    public ApiError(Exception exception)
    {
        Message = exception.Message;
        StackTrace = exception.StackTrace;
    }
    
    public ApiError(Notification notification)
    {
        Message = notification.Message;
        StackTrace = null;
    }
}