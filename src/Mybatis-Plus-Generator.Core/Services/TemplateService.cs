using com.baomidou.mybatisplus.generator;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Mybatis_Plus_Generator.Core.Services;

internal class TemplateService : ITemplateService
{
    public const string Config = nameof(Config);
    public const string Builder = nameof(Builder);

    public TemplateService()
    {
        GeneratorConstructor = typeof(AutoGenerator)
            .GetConstructors()[0];
        var primaryConfig =  GeneratorConstructor
            .GetParameters()[0]
            .ParameterType;
        PrimaryTemplate = new TemplateInfo()
        {
            ConfigType = primaryConfig,
            Name = primaryConfig.Name,
            Fields = GetTemplateInfo(primaryConfig.GetNestedType(Builder)!)
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
                        Fields = GetTemplateInfo(builder),
                    });
                    return c;
                });
    }

    public ConstructorInfo GeneratorConstructor { get; }
    public TemplateInfo PrimaryTemplate { get;  }
    public ObservableCollection<TemplateInfo> AdditionalTemplates { get; }
    private static ObservableCollection<TemplateItemInfo> GetTemplateInfo(Type type)
    {
        return type
            .GetMethods()
            .Where(m => m.ReturnType == type)
            .OrderBy(x => x.Name)
            .Aggregate(new List<TemplateItemInfo>(),
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
                            AllowMultiple = m.Name.StartsWith("add"),
                            FieldName = m.Name,
                            Methods = { m },
                        });
                    }

                    return d;
                })
            .Append(type
                .GetConstructors()
                .Aggregate(new TemplateItemInfo
                {
                    AllowMultiple = false,
                    FieldName = type.Name,
                    IsCtor = true,
                }, (o, c) =>
                {
                    o.Methods.Add(c); return o;
                }))
            .OrderBy(x=> !x.IsCtor)
            .Aggregate(new ObservableCollection<TemplateItemInfo>(), (o, c) =>
            {
                o.Add(c);
                return o;
            });
    }
}