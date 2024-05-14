using CashFlow.Domain.Abstractions.Repositories;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterExpenseUseCase(IExpensesRepository expensesRepository, IUnitOfWork unitOfWork)
    {
        _expensesRepository = expensesRepository;
        _unitOfWork = unitOfWork;
    }

    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };

        _expensesRepository.Add(entity);

        _unitOfWork.Commit();

        //to do validations
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if(result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
