using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Linq;

namespace Mybatis_Plus_Generator.ViewModels;

internal partial class ConfigItemInfoViewModel : ConfigItemInfo
{
    public enum ArgTypes
    {
        NoArg,
        SingleArg,
        MultiArg
    }

    public ArgTypes ArgType => SelectMethod.GetParameters().Length switch
    {
        0 => ArgTypes.NoArg,
        1 => ArgTypes.SingleArg,
        _ => ArgTypes.MultiArg
    };

    /// <summary>
    /// 可选
    /// </summary>
    public bool ShowSwitch => 
        !TemplateItemInfo!.IsCtor || CanIgnore;
    /// <summary>
    /// 可以忽略
    /// </summary>
    public bool CanIgnore => canIgnore ??= 
        TemplateItemInfo!.IsCtor && TemplateItemInfo.Methods.Any(x => x.GetParameters().Length == 0);

    private bool? canIgnore;

    public SwitchCondition Condition => TemplateItemInfo!.AllowMultiple
        ? IsGenerated
            ? SwitchCondition.ShowRemove
            : SwitchCondition.ShowAdd
        : SwitchCondition.None;

    public ConfigItemArgInfo Arg => SelectMethod.GetParameters().Length == 0 ? null : Args[0];
}