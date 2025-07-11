﻿using System.Text.RegularExpressions;
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
        
        Address = addres.Trim().ToLower();
    }

    protected Email()
    {
        
    }

    public string Address { get; }
    public string Hash => Address.ToBase64();
    public Verification Verification { get; private set; } = new();

    public void ResendVerification()
       => Verification = new Verification();
    
    
    public static implicit operator string(Email email) 
        => email.ToString();
    
    public static implicit operator Email(string address) 
        => new Email(address);
    
    public override string ToString()
        => Address;

    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}