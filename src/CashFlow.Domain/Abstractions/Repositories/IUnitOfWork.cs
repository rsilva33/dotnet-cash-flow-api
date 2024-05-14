namespace CashFlow.Domain.Abstractions.Repositories;

public interface IUnitOfWork
{
    void Commit();
}
