using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigRecord<TConfigInfo,TConfigItemInfo> : ObservableObject 
        where TConfigInfo : ConfigInfo<TConfigItemInfo>
        where TConfigItemInfo : ConfigItemInfo
    {
        [ObservableProperty] private string? configName;
        [ObservableProperty] private TConfigInfo? fixedConfig;
        [ObservableProperty] private ObservableCollection<TConfigInfo> configs = new();
    }
}
