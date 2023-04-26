using System;
using System.Globalization;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Converters
{
    public class LangConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string key)
                {
                    return Langs.Lang.ResourceManager.GetString(key) ?? key;
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
}
