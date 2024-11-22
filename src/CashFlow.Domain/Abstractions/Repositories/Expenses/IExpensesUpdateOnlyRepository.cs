namespace CashFlow.Domain.Abstractions.Repositories.Expenses;

public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetById(Domain.Entities.User user, long id);
    void Update(Expense expense);
}
