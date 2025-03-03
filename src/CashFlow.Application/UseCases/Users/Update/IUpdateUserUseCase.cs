namespace CashFlow.Application.UseCases.Expenses.Users.Update;

public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}