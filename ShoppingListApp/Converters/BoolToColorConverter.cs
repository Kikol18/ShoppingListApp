using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ShoppingListApp.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isPurchased && isPurchased)
            {
                return Colors.Gray;
            }
            return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
