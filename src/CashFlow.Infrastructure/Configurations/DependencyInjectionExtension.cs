using CashFlow.Domain.Repositories;
using CashFlow.Infrastructure.Services.LoggedUser;

namespace CashFlow.Infrastructure.Configurations;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();
        
        AddToken(services, configuration);
        AddRepositories(services);

        if (configuration.IsTestEnvironment() is false)
            AddDbContext(services, configuration);
    }

    private static void AddToken(this IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        //forma customizado para retornar a implementacao para interface
        services.AddScoped<IAccessTokenGenerator>(config =>
            new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var serverVersion = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<CashFlowDbContext>(config =>
            config.UseMySql(connectionString, serverVersion));
    }
}
