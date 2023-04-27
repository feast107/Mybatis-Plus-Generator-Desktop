using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigItemInfo : ObservableObject
    {
        public enum SwitchCondition
        {
            ShowAdd,
            ShowRemove,
            None
        }

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

        [ObservableProperty] private bool isEnable = true;

        [ObservableProperty] private bool isGenerated = false;

        [ObservableProperty] private MethodBase? selectMethod;
    }
}
