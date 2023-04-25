using com.baomidou.mybatisplus.generator;
using com.baomidou.mybatisplus.generator.config;
using Mybatis_Plus_Generator.Core.Extensions;

namespace Mybatis_Plus_Generator.Core
{
    public class Generator
    {
        public void Generate()
        {
            var dataSourceConfigs = MyBatisConfigExtension.ExportFunc<DataSourceConfig.Builder>();
            var globalConfigs = MyBatisConfigExtension.ExportFunc<GlobalConfig.Builder>();
            var packageConfigs = MyBatisConfigExtension.ExportFunc<PackageConfig.Builder>();
            var injectConfigs = MyBatisConfigExtension.ExportFunc<InjectionConfig.Builder>();
            var strategyConfigs = MyBatisConfigExtension.ExportFunc<StrategyConfig.Builder>();
            var controllerConfigs = strategyConfigs;
            var serviceConfigs = strategyConfigs;
            var mapperConfigs = strategyConfigs;
        }
    }
}