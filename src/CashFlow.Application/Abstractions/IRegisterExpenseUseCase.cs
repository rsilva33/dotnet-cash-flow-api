namespace CashFlow.Application.Abstractions;

public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request);
}
