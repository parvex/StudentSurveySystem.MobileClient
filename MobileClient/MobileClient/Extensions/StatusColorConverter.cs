using System;
using System.Globalization;
using IO.Swagger.Model;
using Xamarin.Forms;

namespace MobileClient.Extensions
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    return (SurveyStatus) value switch
                    {
                        SurveyStatus.Active => Color.PaleGreen,
                        SurveyStatus.Draft => Color.White,
                        _ => Color.LightGray
                    };
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}