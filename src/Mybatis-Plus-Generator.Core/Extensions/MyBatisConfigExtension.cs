using System.Reflection;
using com.baomidou.mybatisplus.generator.config;

namespace Mybatis_Plus_Generator.Core.Extensions
{
    public static class MyBatisConfigExtension
    {
        private static readonly List<string> BuilderBaseMethods;

        static MyBatisConfigExtension()
        {
            BuilderBaseMethods = typeof(java.lang.Object).GetMethods().Select(x => x.Name).ToList();
            BuilderBaseMethods.AddRange(typeof(IConfigBuilder).GetMethods().Select(x => x.Name).ToList());
        }

        public static List<MethodInfo> ExportFunc<T>() where T : IConfigBuilder
        {
            return typeof(T).GetMethods().Where(x=>x.ReturnType == typeof(T)).ToList();
        }
    }
}
