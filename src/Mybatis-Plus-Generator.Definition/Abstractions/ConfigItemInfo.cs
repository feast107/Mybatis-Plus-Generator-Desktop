using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigItemInfo : ObservableObject
    {
        /// <summary>
        /// 关联模板
        /// </summary>
        [ObservableProperty] private TemplateItemInfo? templateInfo;
        /// <summary>
        /// 值
        /// </summary>
        [ObservableProperty] private string? value;
        /// <summary>
        /// 值类型
        /// </summary>
        [ObservableProperty] private Type? valueType;
    }
}
