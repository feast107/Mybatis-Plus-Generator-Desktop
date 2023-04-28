using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Converters;

internal class InverseBool2VisibilityCollapsedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not Visibility.Visible;
    }
}