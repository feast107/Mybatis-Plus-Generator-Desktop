using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Converters;

internal abstract class ArgTypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is ConfigItemArgInfo info && Condition(info) ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    protected abstract bool Condition(ConfigItemArgInfo value);
}

internal class TypeText2VisibilityConverter : ArgTypeConverter
{
    protected override bool Condition(ConfigItemArgInfo value)
    {
        return value.ArgType == typeof(string) && !value.IsPassword;
    }
}
internal class TypePassword2VisibilityConverter : ArgTypeConverter
{
    protected override bool Condition(ConfigItemArgInfo value)
    {
        return value.ArgType == typeof(string) && value.IsPassword;
    }
}

internal class TypeSelect2VisibilityConverter : ArgTypeConverter
{
    protected override bool Condition(ConfigItemArgInfo value)
    {
        return value.ArgType.IsInterface;
    }
}