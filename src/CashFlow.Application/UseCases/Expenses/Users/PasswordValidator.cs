using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.Expenses.Users;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";
    public override string Name => 
         "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        //"{ErrorMessage}"
        $"{{{ERROR_MESSAGE_KEY}}}";

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if(password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (ValidateUpperCaseLetter().IsMatch(password) is false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (ValidateLowerCaseLetter().IsMatch(password) is false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (ValidateNumbers().IsMatch(password) is false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (ValidateSpecialSymbols().IsMatch(password) is false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        return true;
    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex ValidateUpperCaseLetter();

    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex ValidateLowerCaseLetter();

    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex ValidateNumbers();

    [GeneratedRegex(@"[\!\?\*\.]+")]
    private static partial Regex ValidateSpecialSymbols();
}
