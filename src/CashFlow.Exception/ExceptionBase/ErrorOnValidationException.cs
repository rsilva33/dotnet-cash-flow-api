namespace CashFlow.Exception.ExceptionBase;

public class ErrorOnValidationException : CashFlowException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorsMessages)
        : base(string.Empty) =>
        _errors = errorsMessages;


    public override int StatusCode =>
        (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors() =>
        _errors;
}
