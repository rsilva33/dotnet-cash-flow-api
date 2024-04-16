namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    //Novas versoes do csharp podemos utilizar o required para substituir o construtor
    //public required string ErrorMessage { get; set; } = string.Empty;
    public List<string> ErrorMessage { get; set; }

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessage = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorMessage) => ErrorMessage = errorMessage;
}
