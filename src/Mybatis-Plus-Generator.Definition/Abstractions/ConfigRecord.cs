using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigRecord : ObservableObject
    {
        [ObservableProperty] private string? configName;
        [ObservableProperty] private ConfigInfo? fixedConfig;
        [ObservableProperty] private ObservableCollection<ConfigInfo> configs = new();
    }
}
