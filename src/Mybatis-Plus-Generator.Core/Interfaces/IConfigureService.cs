using System.Collections.ObjectModel;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Interfaces
{
    public interface IConfigureService<out TConfigInfo> where TConfigInfo : ConfigInfo
    {
        ObservableCollection<ConfigRecord> Records { get; }
        ConfigRecord CreateRecord(string name);
        TConfigInfo Instantiate(TemplateInfo template, string name);
    }
}
