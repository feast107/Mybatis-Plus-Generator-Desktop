using System.Reflection;
using com.baomidou.mybatisplus.generator.config;
using Mybatis_Plus_Generator.Core.Extensions;

namespace Mybatis_Plus_Generator.Core
{
    public static class ConfigExporter
    {
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
    }
}