using System.Collections.ObjectModel;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Interfaces
{
    public interface IConfigureService<TConfigRecord, out TConfigInfo, TConfigItemInfo>
        where TConfigRecord : ConfigRecord<TConfigInfo, TConfigItemInfo>
        where TConfigInfo : ConfigInfo<TConfigItemInfo>
        where TConfigItemInfo : ConfigItemInfo
    {
        ObservableCollection<TConfigRecord> Records { get; }
        TConfigRecord CreateRecord(string name);
        TConfigInfo Instantiate(TemplateInfo template, string name);
    }
}
