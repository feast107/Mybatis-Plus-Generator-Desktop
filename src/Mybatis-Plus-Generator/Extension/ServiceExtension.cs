using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.ViewModels;

namespace Mybatis_Plus_Generator.Extension
{
    internal static class ServiceExtension
    {
        public static IServiceCollection AddViewModels(this IServiceCollection collection)
        {
            return collection.AddTransient<ConfigItemInfoViewModel>()
            .AddTransient<ConfigInfoViewModel>()
            .AddTransient<ConfigRecordViewModel>()
            .AddTransient<ConfigPageViewModel>();
        }
    }
}
