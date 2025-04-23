using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Identities;

public class IdentityErrorExtension : IdentityErrorDescriber
{
    public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = "Ocorreu um erro desconhecido." }; }
    public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Falha de concorrência otimista, o objeto foi modificado." }; }
    public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Senha incorreta." }; }
    public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Token inválido." }; }
    public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Já existe um usuário com este login." }; }
    public override IdentityError InvalidUserName(string? userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"O login '{userName}' não é válido, só pode conter letras ou dígitos." }; }
    public override IdentityError InvalidEmail(string? email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"O e-mail '{email}' não é válido." }; }
    public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"O login '{userName}' já está em uso." }; }
    public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"O e-mail '{email}' já está em uso." }; }
    public override IdentityError InvalidRoleName(string? role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"O papel '{role}' não é válido." }; }
    public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"O papel '{role}' já está em uso." }; }
    public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "O usuário já tem uma senha definida." }; }
    public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "O bloqueio de usuário não está habilitado para este usuário." }; }
    public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"O usuário já possui o papel '{role}'." }; }
    public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"O usuário não possui o papel '{role}'." }; }
    public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"As senhas devem conter pelo menos {length} caracteres." }; }
    public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "As senhas devem conter pelo menos um caractere não alfanumérico." }; }
    public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "As senhas devem conter pelo menos um dígito ('0'-'9')." }; }
    public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "As senhas devem conter pelo menos um caractere minúsculo ('a'-'z')." }; }
    public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "As senhas devem conter pelo menos um caractere maiúsculo ('A'-'Z')." }; }
}