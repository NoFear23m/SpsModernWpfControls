using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SpsModernWpfControls.Controls.Icon
{
    public class XamlPathIcon : XamlIcon
    {


        static XamlPathIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XamlPathIcon), new FrameworkPropertyMetadata(typeof(XamlPathIcon)));
        }

        public Path XamlPath
        {
            get => (Path)GetValue(XamlPathProperty);
            set => SetValue(XamlPathProperty, value);
        }

        public static readonly DependencyProperty XamlPathProperty =
            DependencyProperty.Register("XamlPath", typeof(FrameworkElement), typeof(XamlPathIcon), new PropertyMetadata(XamlPathPropertyChanged));

        private static void XamlPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (((XamlPathIcon)d).IsEnabled)
                {
                    ((Path)e.NewValue).Fill = ((XamlPathIcon)d).IconForeground;
                }
                else
                {
                    ((Path)e.NewValue).Fill = ((XamlPathIcon)d).DisabledForeground;
                }
                
            }
        }
    }
}
