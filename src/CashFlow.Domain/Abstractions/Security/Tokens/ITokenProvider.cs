namespace CashFlow.Domain.Abstractions.Security.Tokens;

public interface ITokenProvider
{
    string TokenOnRequest();
}