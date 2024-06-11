namespace CashFlow.Domain.Abstractions.Security.Cryptograpy;

public interface IPasswordEncripter
{
    string Encrypt(string password);
}
