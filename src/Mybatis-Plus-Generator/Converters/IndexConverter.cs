using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Converters
{
    public class IndexConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value -1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
