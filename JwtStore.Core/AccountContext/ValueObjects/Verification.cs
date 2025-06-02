using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public class Verification : ValueObject
{
    public Verification()
    {
        
    }
    public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
    public DateTime? VerifiedAt { get; private set; } = null;
    public bool IsActive => VerifiedAt != null && ExpiresAt == null;

    public void Verify(string code)
    {
        if(IsActive)
           throw new Exception("This code is already verified");
        
        if(ExpiresAt < DateTime.UtcNow)
            throw new Exception("This code has expired");
        
        if(!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Invalid code");

        ExpiresAt = null;
        VerifiedAt = DateTime.UtcNow;
    }
}