using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request) 
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Name.Length, 160, "Name", "Nome inválido")
            .IsGreaterThan(request.Name.Length, 3, "Name", "Nome inválido")
            .IsLowerThan(request.Password.Length, 40, "Password", "Senha inválida")
            .IsGreaterThan(request.Password.Length, 8, "Password", "Senha inválida")
            .IsEmail(request.Email, "Email", "Email inválido");
}