using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigInfo<TConfigItemInfo> : ObservableObject where TConfigItemInfo : ConfigItemInfo
{
    /// <summary>
    /// 关联模板
    /// </summary>
    [ObservableProperty] private TemplateInfo templateInfo = null!;

    /// <summary>
    /// 配置项
    /// </summary>
    [ObservableProperty] private ObservableCollection<TConfigItemInfo> configItems = new();

    /// <summary>
    /// 配置名称
    /// </summary>
    [ObservableProperty] private string configName = null!;

    /// <summary>
    /// 配置类型
    /// </summary>
    public Type ConfigType => TemplateInfo.ConfigType;

}