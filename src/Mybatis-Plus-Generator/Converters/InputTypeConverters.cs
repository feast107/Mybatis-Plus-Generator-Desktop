using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Mybatis_Plus_Generator.ViewModels;

namespace Mybatis_Plus_Generator.Converters;

internal class InputNoArgConverter : EnumToVisibilityConverter<ConfigItemInfoViewModel.InputTypes>
{
    protected override Visibility Condition(ConfigItemInfoViewModel.InputTypes condition)
    {
        return condition switch
        {
            ConfigItemInfoViewModel.InputTypes.NoArg => Visibility.Visible,
            _ => Visibility.Collapsed,
        };
    }
}
internal class InputStringConverter : EnumToVisibilityConverter<ConfigItemInfoViewModel.InputTypes>
{
    protected override Visibility Condition(ConfigItemInfoViewModel.InputTypes condition)
    {
        return condition switch
        {
            ConfigItemInfoViewModel.InputTypes.StringArg => Visibility.Visible,
            _ => Visibility.Collapsed,
        };
    }
}
internal class InputMultiStringConverter : EnumToVisibilityConverter<ConfigItemInfoViewModel.InputTypes>
{
    protected override Visibility Condition(ConfigItemInfoViewModel.InputTypes condition)
    {
        return condition switch
        {
            ConfigItemInfoViewModel.InputTypes.MultiStringArg => Visibility.Visible,
            _ => Visibility.Collapsed,
        };
    }
}