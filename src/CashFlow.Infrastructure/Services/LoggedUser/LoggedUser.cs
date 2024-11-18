using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Infrastructure.Services.LoggedUser;

internal class LoggedUser : ILoggedUser
{
    private readonly CashFlowDbContext _dbContext;

    public LoggedUser(CashFlowDbContext dbContext) => _dbContext = dbContext;

    public async Task<User> Get()
    {
        var token = "";

        var tokenHandler = new JwtSecurityTokenHandler();
        
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        
        var identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

        return await _dbContext.Users.AsNoTracking().FirstAsync(user => 
            user.UserIdentifier == Guid.Parse(identifier));
    }
}