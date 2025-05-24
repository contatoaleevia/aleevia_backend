namespace Domain.Exceptions.Faqs;
public class AnyItemsToImportException()
    : ApiException("Não foi encontrado nenhum registro válido para importar", 400);