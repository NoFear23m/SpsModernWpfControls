using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SpsModernWpfControls.Controls.Converter
{
    public class BooleanToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToBoolean(value))
                return Visibility.Visible;
            else
                if (parameter != null && parameter.ToString() == "H")
            {
                return Visibility.Hidden;
            }
            else
            {
                return Visibility.Collapsed;
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
