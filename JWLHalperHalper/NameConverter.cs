using System;
using System.Globalization;
using System.Windows.Data;

namespace JWLHalperHalper
{
    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return ((string)value).Replace("JWLHelper", "").Replace(".ini", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
