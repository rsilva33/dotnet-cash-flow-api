namespace CashFlow.Domain.Abstractions.Security.Cryptograpy;

public interface IPasswordEncrypter
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}
