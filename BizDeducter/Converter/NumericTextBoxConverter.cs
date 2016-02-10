using BizDeducter.Helpers;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace BizDeducter.Converter
{
    public class NumericTextBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyService.Get<IObjectToDoubleConverterHelper>().Convert(value);
        }
    }
}
