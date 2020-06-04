using System;
using System.Globalization;
using Xamarin.Forms;

namespace MobileClient.Extensions
{
    public class IntEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum)
            {
                return (int)value;
            }
            return 0;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                var type = Nullable.GetUnderlyingType(targetType);
                if (type != null)
                {
                    return Enum.ToObject(type, value);
                }

                return Enum.ToObject(targetType, value);
            }
            return 0;
        }
    }
}