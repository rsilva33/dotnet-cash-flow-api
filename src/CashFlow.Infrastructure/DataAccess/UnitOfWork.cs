namespace CashFlow.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly CashFlowDbContext _context;

    public UnitOfWork(CashFlowDbContext context) =>
        _context = context;

    public async Task CommitAsync() =>
        await _context.SaveChangesAsync();
}
