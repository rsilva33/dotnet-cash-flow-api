namespace CashFlow.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    //extension function
    public static bool IsTestEnvironment(this IConfiguration  configuration) =>
        configuration.GetValue<bool>("InMemoryTest");
}
