using CommunityToolkit.Mvvm.Input;
using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Linq;
using IConfigureService = 
    Mybatis_Plus_Generator.Core.Interfaces.IConfigureService<
    Mybatis_Plus_Generator.ViewModels.ConfigRecordViewModel,
    Mybatis_Plus_Generator.ViewModels.ConfigInfoViewModel,
    Mybatis_Plus_Generator.ViewModels.ConfigItemInfoViewModel>;

namespace Mybatis_Plus_Generator.ViewModels
{
    internal partial class ConfigInfoViewModel : ConfigInfo<ConfigItemInfoViewModel>
    {
        private readonly IConfigureService configureService;

        public ConfigInfoViewModel(IConfigureService configureService)
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
                    ConfigItems.Insert(i + 1, new ConfigItemInfoViewModel()
                    {
                        TemplateInfo = templateItem,
                        IsGenerated = true,
                    });
                    return;
                }
            }
        }
        [RelayCommand]
        void RemoveConfig(ConfigItemInfoViewModel configInfo)
        {
            ConfigItems.Remove(configInfo);
        }
    }
}
