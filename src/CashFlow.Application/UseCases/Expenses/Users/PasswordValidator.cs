using FluentValidation.Validators;

namespace CashFlow.Application.UseCases.Expenses.Users;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "PasswordValdator";

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        throw new NotImplementedException();
    }
}
