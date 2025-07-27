using JwtStore.Core.SharedContext.Entities;

namespace JwtStore.Core.AccountContext.Entities;

public class Role : Entity
{
    public string Name { get; set; }
    public IEnumerable<User> Users { get; set; } = [];
}