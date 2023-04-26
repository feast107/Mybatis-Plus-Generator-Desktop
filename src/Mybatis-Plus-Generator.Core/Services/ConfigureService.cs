using com.baomidou.mybatisplus.generator.config.builder;
using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;

namespace Mybatis_Plus_Generator.Core.Services
{
    internal class ConfigureService : IConfigureService
    {
        private Dictionary<string,Func<ConfigBuilder>> configBuilders = new();
        public ConfigInfo DataSourceConfig { get; }

        public ObservableCollection<ConfigInfo> GetConfigures<T>(string field) where T : ConfigBuilder
        {
            throw new NotImplementedException();
        }

        public List<Type> GetConfiguresTypes()
        {
            return ConfigExporter.ExportConfigs();
        }
    }
}
