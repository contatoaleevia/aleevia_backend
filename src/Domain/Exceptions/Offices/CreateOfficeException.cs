namespace Domain.Exceptions.Offices;

public class CreateOfficeException(string name)
    : ApiException($"Ocorreu um erro ao criar o escritório: {name}", 400);