using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigRecord<TConfigInfo, TConfigItemInfo> : ObservableObject
    where TConfigInfo : ConfigInfo<TConfigItemInfo>
    where TConfigItemInfo : ConfigItemInfo
{
    [ObservableProperty] private string configName = string.Empty;
    [ObservableProperty] private TConfigInfo fixedConfig = null!;
    [ObservableProperty] private ObservableCollection<TConfigInfo> configs = new();
}