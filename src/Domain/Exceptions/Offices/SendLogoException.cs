namespace Domain.Exceptions.Offices;

public class SendLogoException(string message) 
    : ApiException($"Ocorreu o seguinte erro ao fazer o upload da logo: {Environment.NewLine}{message}", 400);
