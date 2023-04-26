using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    /// <summary>
    /// 配置模板
    /// </summary>
    public partial class TemplateInfo : ObservableObject
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        [ObservableProperty] private string? name;
        /// <summary>
        /// 模板类型
        /// </summary>
        [ObservableProperty] private Type? configType;
        /// <summary>
        /// 配置函数
        /// </summary>
        [ObservableProperty] private ObservableCollection<TemplateItemInfo> fields = new();
    }
}
