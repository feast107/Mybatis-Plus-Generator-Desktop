using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Converters;

public abstract class EnumToVisibilityConverter<TEnum> : IValueConverter where TEnum : Enum
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not TEnum condition 
            ? Visibility.Collapsed 
            : Condition(condition);
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    protected abstract Visibility Condition(TEnum condition);
}