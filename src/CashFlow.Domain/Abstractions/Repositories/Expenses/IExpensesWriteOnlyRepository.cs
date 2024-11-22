namespace CashFlow.Domain.Abstractions.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);

    Task Delete(long id);
}
