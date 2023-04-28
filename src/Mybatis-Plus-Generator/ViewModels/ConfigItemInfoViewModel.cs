using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Linq;

namespace Mybatis_Plus_Generator.ViewModels
{
    internal class ConfigItemInfoViewModel : ConfigItemInfo
    {
        public enum InputTypes
        {
            NoArg,
            StringArg,
            MultiStringArg
        }

        public InputTypes InputType => SelectMethod.GetParameters().Length switch
        {
            0 => InputTypes.NoArg,
            1 => InputTypes.StringArg,
            _ => InputTypes.MultiStringArg
        };

        /// <summary>
        /// 可选
        /// </summary>
        public bool ShowSwitch => 
            !TemplateInfo!.IsCtor || CanIgnore;
        /// <summary>
        /// 可以忽略
        /// </summary>
        public bool CanIgnore => canIgnore ??= 
            TemplateInfo!.IsCtor && TemplateInfo.Methods.Any(x => x.GetParameters().Length == 0);

        private bool? canIgnore;

        public SwitchCondition Condition => TemplateInfo!.AllowMultiple
            ? IsGenerated
                ? SwitchCondition.ShowRemove
                : SwitchCondition.ShowAdd
            : SwitchCondition.None;
    }
}
