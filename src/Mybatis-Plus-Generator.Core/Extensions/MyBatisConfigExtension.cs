using System.Reflection;
using com.baomidou.mybatisplus.generator.config;

namespace Mybatis_Plus_Generator.Core.Extensions
{
    public static class MyBatisConfigExtension
    {
        public static Dictionary<string, List<MethodInfo>> ExportBuilderFunc<T>() where T : IConfigBuilder
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
    }
}
