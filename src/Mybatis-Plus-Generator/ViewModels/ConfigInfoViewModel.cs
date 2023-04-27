using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;
using Mybatis_Plus_Generator.Langs;
using Mybatis_Plus_Generator.Visuals.Controls;

namespace Mybatis_Plus_Generator.ViewModels
{
    public partial class ConfigInfoViewModel : ConfigInfo
    {
        private readonly IConfigureService<ConfigInfoViewModel> configureService;

        public ConfigInfoViewModel(IConfigureService<ConfigInfoViewModel> configureService)
        {
            this.configureService = configureService;
        }

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
