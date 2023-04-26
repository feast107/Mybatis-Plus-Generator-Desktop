using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using Mybatis_Plus_Generator.Definition.Abstractions;
using Mybatis_Plus_Generator.Visuals.Controls;
using javax.swing.text;
using Mybatis_Plus_Generator.Core.Interfaces;

namespace Mybatis_Plus_Generator.ViewModels
{
    public partial class ConfigPageViewModel : ObservableObject
    {
        private IConfigureService configureService;

        public ConfigPageViewModel(IConfigureService configureService){
            this.configureService = configureService;
        }

        [ObservableProperty] private string? configName;
        [ObservableProperty] private ObservableCollection<ConfigRecord> records = new();
        [ObservableProperty] private ConfigRecord? current;
        [ObservableProperty] private ObservableCollection<TemplateInfo> templates = new();

        [RelayCommand]
        async Task SelectTemplate(TemplateInfo template)
        {
            var dialog = new ConfigNameDialog();
            var res = await DialogHost.Show(dialog, "NewConfig");
            if (res is not true) return;
            Current!.Configs.Add(configureService.Instantiate(template,dialog.Title.Text));
        }

        [RelayCommand]
        async Task RemoveConfig(ConfigInfo config)
        {
            if (config.Equals(Current!.FixedConfig))
            {
                 await DialogHost.Show(new SimpleDialog("Can not delete fixed config"), "NewConfig");
                 return;
            }

            Current.Configs.Remove(config);
        }

        public Func<Task> ShowDialog { get; init; }
    }
}
