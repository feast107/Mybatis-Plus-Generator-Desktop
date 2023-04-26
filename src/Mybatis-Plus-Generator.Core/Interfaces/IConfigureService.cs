using System.Collections.ObjectModel;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Interfaces
{
    public interface IConfigureService
    {
        ObservableCollection<ConfigRecord> Records { get; }
        ConfigRecord CreateRecord(string name);
        ConfigInfo Instantiate(TemplateInfo template, string name);
    }
}
