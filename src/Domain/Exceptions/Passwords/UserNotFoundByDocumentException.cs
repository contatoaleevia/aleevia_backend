namespace Domain.Exceptions.Passwords;

public class UserNotFoundByDocumentException(string document)
    : ApiException($"Usuário com Documento: {document} não encontrado", 404);