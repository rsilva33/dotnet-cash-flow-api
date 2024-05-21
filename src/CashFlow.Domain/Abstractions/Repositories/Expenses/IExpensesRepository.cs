using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Abstractions.Repositories.Expenses;

public interface IExpensesRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> GetAll();
}
