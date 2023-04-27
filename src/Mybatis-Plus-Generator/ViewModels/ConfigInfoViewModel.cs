using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.ViewModels
{
    public partial class ConfigInfoViewModel : ConfigInfo
    {
        private readonly IConfigureService<ConfigInfoViewModel> configureService;

        public ConfigInfoViewModel(IConfigureService<ConfigInfoViewModel> configureService)
        {
            this.configureService = configureService;
        }

        public bool IgnoreCtor => ignoreCtor ??= TemplateInfo!
            .Fields
            .Where(x => x.IsCtor)
            .All(x => x.Methods.All(c => c.GetParameters().Length == 0));

        private bool? ignoreCtor;

        [RelayCommand]
        void AddConfig(TemplateItemInfo templateItem)
        {
            for (var i = 0; i < base.ConfigItems.Count; i++)
            {
                if (ConfigItems[i].TemplateInfo == templateItem)
                {
                    ConfigItems.Insert(i + 1, new ConfigItemInfo()
                    {
                        TemplateInfo = templateItem,
                        IsGenerated = true
                    });
                    return;
                }
            }
        }
        [RelayCommand]
        void RemoveConfig(ConfigItemInfo configInfo)
        {
            ConfigItems.Remove(configInfo);
        }
    }
}
