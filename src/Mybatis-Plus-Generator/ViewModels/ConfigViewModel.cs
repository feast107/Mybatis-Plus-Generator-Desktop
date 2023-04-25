using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace Mybatis_Plus_Generator.ViewModels
{
    public partial class ConfigViewModel : ObservableObject
    {
        [ObservableProperty] private string? configName;
        [ObservableProperty] private Dictionary<string,dynamic> configs = new();
    }
}
