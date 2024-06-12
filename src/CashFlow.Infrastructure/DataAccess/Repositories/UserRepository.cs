using CashFlow.Domain.Abstractions.Repositories.User;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class UserRepository : IUserReadOnlyRepository, 
                                IUserWriteOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public UserRepository(CashFlowDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<bool> ExistActiveUserWithEmail(string email) =>
        await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));

    public async Task Add(User user) =>
        await _dbContext.Users.AddAsync(user);

}
