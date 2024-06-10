namespace CashFlow.Infrastructure.DataAccess;

public static class DataBaseMigration
{
    public async static Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
