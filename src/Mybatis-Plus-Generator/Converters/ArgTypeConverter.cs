using Mybatis_Plus_Generator.Definition.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Converters;

internal class ArgTypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is ArgModes info
               && parameter is ArgModes type
               && info == type
            ? Visibility.Visible
            : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

