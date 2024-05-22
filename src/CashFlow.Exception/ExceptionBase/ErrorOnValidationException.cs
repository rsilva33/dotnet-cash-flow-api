namespace CashFlow.Exception.ExceptionBase;

public class ErrorOnValidationException : CashFlowException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorsMessages) 
        : base(string.Empty)
    {
        Errors = errorsMessages;
    }
}
