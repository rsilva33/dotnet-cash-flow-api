﻿namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
