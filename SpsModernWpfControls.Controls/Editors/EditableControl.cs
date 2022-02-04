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
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableControl), new PropertyMetadata(false, IsInEditModelChanged));

        private static void IsInEditModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public Brush HighlightBrush
        {
            get { return (Brush)GetValue(HighlightBrushProperty); }
            set { SetValue(HighlightBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightBrushProperty =
            DependencyProperty.Register("HighlightBrush", typeof(Brush), typeof(EditableControl), new PropertyMetadata(new SolidColorBrush(Colors.AliceBlue)));



        public bool ShowHighlights
        {
            get { return (bool)GetValue(ShowHighlightsProperty); }
            set { SetValue(ShowHighlightsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowHighlights.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowHighlightsProperty =
            DependencyProperty.Register("ShowHighlights", typeof(bool), typeof(EditableTextBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ShowHighlightsChanged));

        private static void ShowHighlightsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }


        public bool ShowEditIcon
        {
            get { return (bool)GetValue(ShowEditIconProperty); }
            set { SetValue(ShowEditIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowEditIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowEditIconProperty =
            DependencyProperty.Register("ShowEditIcon", typeof(bool), typeof(EditableControl), new PropertyMetadata(true));




        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register("ShowIcon", typeof(bool), typeof(EditableTextBox), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public HighlightActivator HighlightActivation
        {
            get { return (HighlightActivator)GetValue(HighlightActivationProperty); }
            set { SetValue(HighlightActivationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightActivation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightActivationProperty =
            DependencyProperty.Register("HighlightActivation", typeof(HighlightActivator), typeof(EditableTextBox), new FrameworkPropertyMetadata(HighlightActivator.Allways, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, HighlightActivationChanged));

        private static void HighlightActivationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((HighlightActivator)e.NewValue == HighlightActivator.Allways)
            {
                d.SetValue(ShowHighlightsProperty, true);
            }
            if ((HighlightActivator)e.NewValue == HighlightActivator.OnHover)
            {
                d.SetValue(ShowHighlightsProperty, false);
            }
            if ((HighlightActivator)e.NewValue == HighlightActivator.OnIconClick)
            {
                d.SetValue(ShowHighlightsProperty, false);
            }
        }
    }
    public enum HighlightActivator
    {
        Allways = 0,
        OnHover = 1,
        OnIconClick = 2
    }

}

