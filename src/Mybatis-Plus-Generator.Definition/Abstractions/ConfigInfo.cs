using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigInfo : ObservableObject
    {
        /// <summary>
        /// 关联模板
        /// </summary>
        [ObservableProperty] private TemplateInfo? templateInfo;
        /// <summary>
        /// 配置项
        /// </summary>
        [ObservableProperty] private ObservableCollection<ConfigItemInfo> configItems = new();
        /// <summary>
        /// 配置名称
        /// </summary>
        [ObservableProperty] private string? configName;
    }
}
