using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Core.Services;

namespace Mybatis_Plus_Generator.Core.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDefaultService(this IServiceCollection collection) 
            => collection.AddSingleton<ITemplateService, TemplateService>()
                .AddSingleton(typeof(IConfigureService<,,>),typeof(ConfigureService<,,>));

        public static IServiceCollection AddDefaultService(this IServiceCollection collection,Type configServiceType)
            => collection.AddSingleton<ITemplateService, TemplateService>()
                .AddSingleton(configServiceType, typeof(ConfigureService<,,>));
    }
}
