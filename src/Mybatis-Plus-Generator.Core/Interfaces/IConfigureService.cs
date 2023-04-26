using com.baomidou.mybatisplus.generator.config.builder;
using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;

namespace Mybatis_Plus_Generator.Core.Interfaces
{
    public interface IConfigureService
    {
        ConfigInfo DataSourceConfig { get; }

        ObservableCollection<ConfigInfo> GetConfigures<T>(string field) where T : ConfigBuilder;

        List<Type> GetConfiguresTypes();
    }
}
