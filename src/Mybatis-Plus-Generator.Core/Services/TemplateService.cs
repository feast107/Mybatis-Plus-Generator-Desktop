using com.baomidou.mybatisplus.generator;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;

namespace Mybatis_Plus_Generator.Core.Services
{
    internal class TemplateService : ITemplateService
    {
        public const string Config = nameof(Config);
        public const string Builder = nameof(Builder);

        public TemplateService()
        {
            var primaryConfig =  typeof(AutoGenerator).GetConstructors()[0].GetParameters()[0].ParameterType;
            PrimaryTemplate = new TemplateInfo()
            {
                ConfigType = primaryConfig,
                Name = primaryConfig.Name,
                Fields = GetTemplateInfo(primaryConfig)
            };

            AdditionalTemplates = typeof(AutoGenerator)
                .GetMethods()
                .Where(x => x.ReturnType == typeof(AutoGenerator) && x.GetParameters().Length == 1)
                .Select(x => x.GetParameters()[0].ParameterType)
                .Aggregate(new ObservableCollection<TemplateInfo>(),
                    (c, t) =>
                    {
                        var builder = t.GetNestedType(Builder);
                        if (builder == null) return c;
                        c.Add(new TemplateInfo()
                        { 
                            ConfigType = t,
                            Name = t.Name,
                            Fields = GetTemplateInfo(builder)
                        });
                        return c;
                    });
        }

        public TemplateInfo PrimaryTemplate { get;  }
        public ObservableCollection<TemplateInfo> AdditionalTemplates { get; }
        private static ObservableCollection<TemplateItemInfo> GetTemplateInfo(Type type)
        {
            return type
                .GetMethods()
                .Where(m => m.ReturnType == type)
                .Aggregate(new ObservableCollection<TemplateItemInfo>(),
                    (d, m) =>
                    {
                        var cache = d.FirstOrDefault(x => x.FieldName == m.Name);
                        if (cache != null)
                        {
                            cache.Methods.Add(m);
                        }
                        else
                        {
                            d.Add(new TemplateItemInfo()
                            {
                                AllowMultiple = false,
                                FieldName = m.Name,
                                Methods = { m }
                            });
                        }

                        return d;
                    });
        }
    }
}
