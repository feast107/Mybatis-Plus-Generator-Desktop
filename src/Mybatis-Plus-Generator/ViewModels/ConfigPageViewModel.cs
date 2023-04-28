using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using Mybatis_Plus_Generator.Definition.Abstractions;
using Mybatis_Plus_Generator.Langs;
using Mybatis_Plus_Generator.Visuals.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mybatis_Plus_Generator.ViewModels;

internal partial class ConfigPageViewModel : ObservableObject
{
    private readonly IConfigureService configureService;

    public ConfigPageViewModel(IConfigureService configureService)
    {
        this.configureService = configureService;
    }

    [ObservableProperty] private string? configName;
    [ObservableProperty] private ObservableCollection<ConfigRecordViewModel> records = new();

    public ConfigRecordViewModel Current
    {
        get => current ??= Records.Count == 0 ? configureService.CreateRecord("默认配置") : Records[0];
        set => SetProperty(ref current, value);
    }

    private ConfigRecordViewModel? current;

    [ObservableProperty] private ObservableCollection<TemplateInfo> templates = new();

    [RelayCommand]
    private async Task SelectTemplate(TemplateInfo template)
    {
        var dialog = new ConfigNameDialog();
        var res = await DialogHost.Show(dialog, "NewConfig");
        if (res is not true) return;
        var name = dialog.Title.Text;
        if (string.IsNullOrWhiteSpace(name))
        {
            await SimpleDialog.Show(Lang.Please_provide_config_name, "NewConfig");
            return;
        }

        if (Current!.Configs.FirstOrDefault(x => x.ConfigName == name) != null)
        {
            await SimpleDialog.Show(Lang.Config_name_exists, "NewConfig");
            return;
        }

        Current!.Configs.Add(configureService.Instantiate(template, dialog.Title.Text));
    }

    [RelayCommand]
    private async Task RemoveConfig(ConfigInfoViewModel config)
    {
        if (config.Equals(Current!.FixedConfig))
        {
            await DialogHost.Show(
                new SimpleDialog(Lang.Can_not_delete_fixed_config),
                "NewConfig");
            return;
        }

        Current.Configs.Remove(config);
    }
}