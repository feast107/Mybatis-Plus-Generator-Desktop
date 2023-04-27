using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Linq;

namespace Mybatis_Plus_Generator.ViewModels
{
    internal class ConfigItemInfoViewModel : ConfigItemInfo
    {
        /// <summary>
        /// 可选
        /// </summary>
        public bool CanSwitch => CanIgnore || !TemplateInfo!.IsCtor;
        /// <summary>
        /// 可以忽略
        /// </summary>
        public bool CanIgnore =>
            canIgnore ??= TemplateInfo!.IsCtor && TemplateInfo.Methods.All(x => x.GetParameters().Length == 0);
        private bool? canIgnore;
        public SwitchCondition Condition => TemplateInfo!.AllowMultiple
            ? IsGenerated
                ? SwitchCondition.ShowRemove
                : SwitchCondition.ShowAdd
            : SwitchCondition.None;
    }
}
