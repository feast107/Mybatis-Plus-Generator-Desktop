using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;

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

        /// <summary>
        /// 可选
        /// </summary>
        public bool CanSwitch => CanIgnore || !TemplateInfo!.IsCtor;
        /// <summary>
        /// 可以忽略
        /// </summary>
        public bool CanIgnore => 
            canIgnore ??= TemplateInfo!.IsCtor && TemplateInfo.Methods.All(x=>x.GetParameters().Length == 0);
        private bool? canIgnore;
        public SwitchCondition Condition => TemplateInfo.AllowMultiple
            ? isGenerated
                ? SwitchCondition.ShowRemove
                : SwitchCondition.ShowAdd
            : SwitchCondition.None;
    }
}
