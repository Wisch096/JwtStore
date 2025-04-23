using System.Text.RegularExpressions;
using JwtStore.Core.SharedContext.Extensions;
using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public partial class Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    public Email(string addres)
    {
        if(string.IsNullOrWhiteSpace(addres))
            throw new Exception("Invalid email address");
        
        Addres = addres.Trim().ToLower();
        
        
    }

    public string Addres { get; }
    public string Hash => Addres.ToBase64();
    
    public static implicit operator string(Email email) 
        => email.ToString();
    
    public static implicit operator Email(string address) 
        => new Email(address);
    
    public override string ToString()
        => Addres;

    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}