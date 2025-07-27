using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Contexts.AccountContext.UseCases.Authenticate;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserByEmailAsync(string requestEmail, CancellationToken cancellationToken)
    {
        return await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Address == requestEmail, cancellationToken);
    }
}