namespace CashFlow.Exception.ExceptionBase;

public class ErrorOnValidationException(List<string> errorsMessages) : CashFlowException
{
    public List<string> Errors { get; set; } = errorsMessages;
}
