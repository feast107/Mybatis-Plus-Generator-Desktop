using com.baomidou.mybatisplus.generator.config;
using System.Reflection;

namespace Mybatis_Plus_Generator.Core.Extensions
{
    public static class ConfigExporter
    {
        public const string Config = nameof(Config);
        public const string Builder = nameof(Builder);
        public static Dictionary<string, Dictionary<string, List<MethodInfo>>> ExportBuildersFunc()
        {
            return new Dictionary<string, Dictionary<string, List<MethodInfo>>>
            {
                { nameof(DataSourceConfig), MyBatisConfigExtension.ExportBuilderFunc<DataSourceConfig.Builder>() },
                { nameof(GlobalConfig), MyBatisConfigExtension.ExportBuilderFunc<GlobalConfig.Builder>() },
                { nameof(PackageConfig), MyBatisConfigExtension.ExportBuilderFunc<PackageConfig.Builder>() },
                { nameof(InjectionConfig), MyBatisConfigExtension.ExportBuilderFunc<InjectionConfig.Builder>() },
                { nameof(StrategyConfig), MyBatisConfigExtension.ExportBuilderFunc<StrategyConfig.Builder>() },
                { $"Controller{nameof(StrategyConfig)}", MyBatisConfigExtension.ExportBuilderFunc<StrategyConfig.Builder>() },
                { $"Service{nameof(StrategyConfig)}", MyBatisConfigExtension.ExportBuilderFunc<StrategyConfig.Builder>() },
                { $"Mapper{nameof(StrategyConfig)}", MyBatisConfigExtension.ExportBuilderFunc<StrategyConfig.Builder>() },
            };
        }

        public static List<Type> ExportConfigs()
        {
            return typeof(IConfigBuilder)
                .Assembly
                .GetExportedTypes()
                .Where(x => x.Name.EndsWith(Config) && x.GetNestedType(Builder) != null)
                .ToList();
        }


    }
}