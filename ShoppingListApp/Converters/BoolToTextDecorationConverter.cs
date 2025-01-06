using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ShoppingListApp.Converters
{
    public class BoolToTextDecorationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool isPurchased && isPurchased)
            {
                return TextDecorations.Strikethrough;
            }

            if (values[1] is int quantity && quantity == 0)
            {
                return TextDecorations.Strikethrough;
            }

            return TextDecorations.None;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}



