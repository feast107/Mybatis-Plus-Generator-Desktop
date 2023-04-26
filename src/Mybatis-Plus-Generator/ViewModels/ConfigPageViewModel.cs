using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.ViewModels
{
    public partial class ConfigPageViewModel : ObservableObject
    {
        [ObservableProperty] private string? configName;
        [ObservableProperty] private ObservableCollection<ConfigTabViewModel> configs = new();
        [ObservableProperty] private ObservableCollection<TemplateInfo> templates = new();

        [RelayCommand]
        void SelectMenu(TemplateInfo template)
        {
            Debugger.Break();
        }
    }
}
