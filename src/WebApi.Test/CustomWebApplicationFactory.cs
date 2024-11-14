using CashFlow.Domain.Abstractions.Security.Cryptograpy;

namespace WebApi.Test;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private User _user;
    private string _password;
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<CashFlowDbContext>(config =>
                {
                    config.UseInMemoryDatabase("InMemoryDbForTesting");
                    config.UseInternalServiceProvider(provider);
                });

                var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<CashFlowDbContext>();
                var passwordEncripter = scope.ServiceProvider.GetRequiredService<IPasswordEncrypter>();
                
                StartDatabase(dbContext, passwordEncripter);
            });
    }
    
    public string GetEmail() => _user!.Email;
    public string GetName() => _user!.Name;
    public string GetPassword() => _password;

    private void StartDatabase(CashFlowDbContext dbContext, IPasswordEncrypter passwordEncrypter)
    {
        _user = UserBuilder.Build();
        _password = _user.Password;
        
        _user.Password = passwordEncrypter.Encrypt(_user.Password);
        
        dbContext.Users.Add(_user);

        dbContext.SaveChanges();
    }
}
