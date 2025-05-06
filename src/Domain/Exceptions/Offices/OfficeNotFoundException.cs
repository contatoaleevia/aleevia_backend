namespace Domain.Exceptions.Offices;
public class OfficeNotFoundException(Guid guid)
: ApiException($"Office com o Id: {guid} não encontrado", 404);