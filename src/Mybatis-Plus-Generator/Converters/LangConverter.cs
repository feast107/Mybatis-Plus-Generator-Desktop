using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Converters;

public class LangConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            switch (value)
            {
                case string key:
                    return Langs.Lang.ResourceManager.GetString(key,culture) ?? key;
                case UIElement:
                    return Langs.Lang.ResourceManager.GetString(parameter.ToString() ?? string.Empty) ?? string.Empty;
            }
        }
        catch
        {
            //
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }


}