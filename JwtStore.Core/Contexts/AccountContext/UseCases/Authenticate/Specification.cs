using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request) 
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Password.Length, 40, "Name", "Nome inválido")
            .IsGreaterThan(request.Password.Length, 8, "Name", "Nome inválido")
            .IsEmail(request.Email, "Email", "Email inválido");
}