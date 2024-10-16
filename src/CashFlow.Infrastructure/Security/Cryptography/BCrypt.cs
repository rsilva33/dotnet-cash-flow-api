﻿namespace CashFlow.Infrastructure.Security.Cryptography;

internal class BCrypt : IPasswordEncrypter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash) =>
        BC.Verify(password, passwordHash);
}
