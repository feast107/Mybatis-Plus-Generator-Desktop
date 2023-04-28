using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Mybatis_Plus_Generator.ViewModels;

namespace Mybatis_Plus_Generator.Converters;

internal class InputNoArgConverter : EnumToVisibilityConverter<ConfigItemInfoViewModel.ArgTypes>
{
    protected override Visibility Condition(ConfigItemInfoViewModel.ArgTypes condition)
    {
        return condition switch
        {
            ConfigItemInfoViewModel.ArgTypes.NoArg => Visibility.Visible,
            _ => Visibility.Collapsed,
        };
    }
}
internal class InputStringConverter : EnumToVisibilityConverter<ConfigItemInfoViewModel.ArgTypes>
{
    protected override Visibility Condition(ConfigItemInfoViewModel.ArgTypes condition)
    {
        return condition switch
        {
            ConfigItemInfoViewModel.ArgTypes.SingleArg => Visibility.Visible,
            _ => Visibility.Collapsed,
        };
    }
}
internal class InputMultiStringConverter : EnumToVisibilityConverter<ConfigItemInfoViewModel.ArgTypes>
{
    protected override Visibility Condition(ConfigItemInfoViewModel.ArgTypes condition)
    {
        return condition switch
        {
            ConfigItemInfoViewModel.ArgTypes.MultiArg => Visibility.Visible,
            _ => Visibility.Collapsed,
        };
    }
}

