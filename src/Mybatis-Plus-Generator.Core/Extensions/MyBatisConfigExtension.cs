using System.Collections.ObjectModel;
using System.Reflection;
using com.baomidou.mybatisplus.generator.config;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Extensions
{
    public static class MyBatisConfigExtension
    {
        public static Dictionary<string, List<MethodInfo>> ExportBuilderFunc<T>()
        {
            return typeof(T)
                .GetMethods()
                .Where(x => x.ReturnType == typeof(T))
                .Aggregate(new Dictionary<string, List<MethodInfo>>(), (d, c) =>
                {
                    if (d.TryGetValue(c.Name, out var ms))
                    {
                        ms.Add(c);
                    }
                    else
                    {
                        d[c.Name] = new List<MethodInfo>() { c };
                    }
                    return d;
                });
        }
        public static ObservableCollection<ConfigInfo> ExportBuilderFunc(Type type)
        {
            return type
                .GetMethods()
                .Where(x => x.ReturnType == type)
                .Aggregate(new ObservableCollection<ConfigInfo>(), (d, c) =>
                {
                    return d;
                });
        }
    }
}
