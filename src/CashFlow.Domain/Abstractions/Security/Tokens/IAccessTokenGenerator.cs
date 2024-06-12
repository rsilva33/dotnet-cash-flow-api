namespace CashFlow.Domain.Abstractions.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}
