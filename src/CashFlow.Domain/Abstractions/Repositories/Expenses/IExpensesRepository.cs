using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Abstractions.Repositories.Expenses;

public interface IExpensesRepository
{
    void Add(Expense expense);
}
