namespace Domain.Exceptions.Offices;
public class OfficeAddressNotFoundException(Guid officeId)
: ApiException($"Não foi encontrado nenhum registro com o Id: {officeId}", 400);