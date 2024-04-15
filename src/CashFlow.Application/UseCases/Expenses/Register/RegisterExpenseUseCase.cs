using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        //to do validations
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleEmpty = string.IsNullOrWhiteSpace(request.Title);

        if(titleEmpty)
            throw new ArgumentException("The title is required.");

        if (request.Amount <= 0)
            throw new ArgumentException("The Amount must be greater than zero.");

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);

        if (result > 0)
            throw new ArgumentException("Expenses cannot be fot the future.");

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (paymentTypeIsValid is false)
            throw new ArgumentException("Payment type is not valid.");
    }
}
