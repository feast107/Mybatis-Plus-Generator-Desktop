using Microsoft.Extensions.DependencyInjection;

namespace Mybatis_Plus_Generator.Core;

public static class Core
{
    public static IServiceCollection Services { get; } = new ServiceCollection();

    private static ServiceProvider? provider;
    public static IServiceProvider Provider => provider ?? throw new Exception("Service hasn't been build");

    public static IServiceProvider Build()
    {
        provider?.Dispose();
        provider = Services.BuildServiceProvider();
        return provider;
    }
}