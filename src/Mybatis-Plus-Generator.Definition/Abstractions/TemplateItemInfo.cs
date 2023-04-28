using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class TemplateItemInfo : ObservableObject
{
    /// <summary>
    /// 配置项名称
    /// </summary>
    [ObservableProperty] private string fieldName = string.Empty;
    /// <summary>
    /// 是否允许多个
    /// </summary>
    [ObservableProperty] private bool allowMultiple;
    /// <summary>
    /// 调用方法
    /// </summary>
    [ObservableProperty] private ObservableCollection<MethodBase> methods = new();
    /// <summary>
    /// 是否是构造函数
    /// </summary>
    [ObservableProperty] private bool isCtor;
}