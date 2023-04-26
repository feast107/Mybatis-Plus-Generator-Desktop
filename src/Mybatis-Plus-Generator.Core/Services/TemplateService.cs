using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using com.baomidou.mybatisplus.generator;
using com.baomidou.mybatisplus.generator.config;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Services
{
    internal class TemplateService : ITemplateService
    {
        public const string Config = nameof(Config);
        public const string Builder = nameof(Builder);

        public TemplateService()
        {
           var ts= typeof(AutoGenerator)
                .GetMethods()
                .Where(x => x.ReturnType == typeof(AutoGenerator) && x.GetParameters().Length == 1);
            ConfigTemplates = ts
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
                            Fields = builder
                                .GetMethods()
                                .Where(m=>m.ReturnType == builder)
                                .Aggregate(new Dictionary<string, List<MethodInfo>>(), (d, m) =>
                                {
                                    if (d.TryGetValue(m.Name, out var ms))
                                    {
                                        ms.Add(m);
                                    }
                                    else
                                    {
                                        d[m.Name] = new() { m };
                                    }
                                    return d;
                                })
                        });
                        return c;
                    });
        }
        public ObservableCollection<TemplateInfo> ConfigTemplates { get; }
    }
}
