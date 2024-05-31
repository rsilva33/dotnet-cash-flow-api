namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf;

public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
{
    private const string CURRENCY_SYMBOL = "€";

    private readonly IExpensesReadOnlyRepository _repository;

    public GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;

        GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);

        if(expenses.Count is 0) 
            return [];

        var document = CreateDocument(month);

        return [];
    }

    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();
                                                                  //{month.ToString("Y")}";
        document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSES_FOR} {month:Y}";
        document.Info.Subject = "Subject";
        document.Info.Author = "Ronaldo Silva";

        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RELAWAY_REGULAR;

        return document;
    }
}
