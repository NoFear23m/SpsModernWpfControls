using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpsModernWpfControls.Controls.Editors
{
    public abstract class EditableControl : Control
    {
        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsInEditMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableControl), new PropertyMetadata(false));


        public Brush HighlightBrush
        {
            get { return (Brush)GetValue(HighlightBrushProperty); }
            set { SetValue(HighlightBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightBrushProperty =
            DependencyProperty.Register("HighlightBrush", typeof(Brush), typeof(EditableControl), new PropertyMetadata(new SolidColorBrush(Colors.AliceBlue)));




        public bool ShowEditIcon
        {
            get { return (bool)GetValue(ShowEditIconProperty); }
            set { SetValue(ShowEditIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowEditIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowEditIconProperty =
            DependencyProperty.Register("ShowEditIcon", typeof(bool), typeof(EditableControl), new PropertyMetadata(true));




    }
}
