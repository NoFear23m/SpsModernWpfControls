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


namespace SpsModernWpfControls.Controls.Icon
{
    public class XamlContentIcon : XamlIcon
    {

        static XamlContentIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XamlContentIcon), new FrameworkPropertyMetadata(typeof(XamlContentIcon)));
        }

        public FrameworkElement XamlIcon
        {
            get => (FrameworkElement)GetValue(XamlIconProperty);
            set => SetValue(XamlIconProperty, value);
        }

        public static readonly DependencyProperty XamlIconProperty =
            DependencyProperty.Register("XamlIcon", typeof(FrameworkElement), typeof(XamlContentIcon), new PropertyMetadata(null));



    }
}



