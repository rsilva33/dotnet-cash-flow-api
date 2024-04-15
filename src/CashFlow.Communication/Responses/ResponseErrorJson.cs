namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    //Novas versoes do csharp podemos utilizar o required para substituir o construtor
    //public required string ErrorMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
