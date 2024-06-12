namespace CashFlow.Domain.Abstractions.Repositories.User;

public interface IUserWriteOnlyRepository
{
    Task Add(Entities.User user);
}