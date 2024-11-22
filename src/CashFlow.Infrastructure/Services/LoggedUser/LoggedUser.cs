namespace CashFlow.Infrastructure.Services.LoggedUser;

internal class LoggedUser : ILoggedUser
{
    private readonly CashFlowDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;
    public LoggedUser(CashFlowDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<User> Get()
    {
        var token = _tokenProvider.TokenOnRequest();
        
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        
        var identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

        return await _dbContext
            .Users.AsNoTracking()
            .FirstAsync(user => 
            user.UserIdentifier == Guid.Parse(identifier));
    }
}