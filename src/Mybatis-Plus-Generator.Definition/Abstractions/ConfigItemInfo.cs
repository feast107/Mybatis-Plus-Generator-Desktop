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

    public ConfigItemInfo()
    {
        PropertyChanged += (_, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(TemplateItemInfo):
                    SelectMethod = TemplateItemInfo.Methods[0];
                    break;
                case nameof(SelectMethod):
                    Args = SelectMethod
                        .GetParameters()
                        .Aggregate(new ObservableCollection<ConfigItemArgInfo>(),
                            (o, c) =>
                        {
                            o.Add(new ConfigItemArgInfo
                            {
                                ArgName = c.Name,
                                ArgType = c.ParameterType,
                            });
                            return o;
                        });
                    OnPropertyChanged(nameof(HasParam));
                    break;
            }
        };
    }

    public string FieldName => TemplateItemInfo.FieldName;
    /// <summary>
    /// 关联模板
    /// </summary>
    [ObservableProperty] private TemplateItemInfo templateItemInfo = null!;
    [ObservableProperty] private bool isEnable = true;
    [ObservableProperty] private bool isGenerated;
    [ObservableProperty] private ObservableCollection<ConfigItemArgInfo> args = null!;
    [ObservableProperty] private MethodBase selectMethod = null!;

    public bool HasParam => SelectMethod.GetParameters().Length != 0;
}