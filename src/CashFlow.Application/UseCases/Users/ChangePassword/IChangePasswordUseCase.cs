namespace CashFlow.Application.UseCases.Expenses.Users.ChangePassword;

public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}