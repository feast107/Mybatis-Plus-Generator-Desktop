using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigItemInfo : ObservableObject
{
    public enum SwitchCondition
    {
        ShowAdd,
        ShowRemove,
        None
    }

    public string FieldName => TemplateItemInfo.FieldName;
    /// <summary>
    /// 关联模板
    /// </summary>
    [ObservableProperty] private TemplateItemInfo templateItemInfo = null!;
    [ObservableProperty] private bool isEnable = true;
    [ObservableProperty] private bool isGenerated;
    [ObservableProperty] private ObservableCollection<ConfigItemArgInfo> args = null!;

    public bool HasParam => SelectMethod.GetParameters().Length != 0;
    public MethodBase SelectMethod
    {
        get => selectMethod ??= ChangeSelectMethod(TemplateItemInfo!.Methods[0]);
        set => ChangeSelectMethod(value);
    }
    private MethodBase? selectMethod;
    private MethodBase ChangeSelectMethod(MethodBase method)
    {
        SetProperty(ref selectMethod, method);
        var param = method.GetParameters();
        Args = param.Aggregate(new ObservableCollection<ConfigItemArgInfo>(), (o, c) =>
        {
            o.Add(new ConfigItemArgInfo()
            {
                ArgName = c.Name,
                ArgType = c.ParameterType,
            });
            return o;
        });
        OnPropertyChanged(nameof(HasParam));
        return method;
    }

}