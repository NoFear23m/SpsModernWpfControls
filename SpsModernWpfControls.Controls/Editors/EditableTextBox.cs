using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpsModernWpfControls.Controls.Editors
{
    public class EditableTextBox : EditableControl
    {
        
        static EditableTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableTextBox), new FrameworkPropertyMetadata(typeof(EditableTextBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button btnView = GetTemplateChild("btnSwitch") as Button;
            TextBox txtBox = GetTemplateChild("txtBox") as TextBox;
            if (btnView != null)
            {
                btnView.Click += BtnView_Click;
            }
            if (txtBox != null)
            {
                txtBox.KeyDown += txtBox_KeyDown;
                txtBox.LostFocus += txtBox_LostFocus;
            }
        }

        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SetValue(IsInEditModeProperty, false);
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { SetValue(IsInEditModeProperty, !(bool)GetValue(IsInEditModeProperty)); }
            if (e.Key == Key.Escape) { SetValue(IsInEditModeProperty, !(bool)GetValue(IsInEditModeProperty)); }
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            SetValue(IsInEditModeProperty, !(bool)GetValue(IsInEditModeProperty));
            TextBox txtBox = GetTemplateChild("txtBox") as TextBox;
            if (txtBox != null && (bool)GetValue(IsInEditModeProperty))
            {
                txtBox.Focus();
                txtBox.SelectAll();
            }
        }

    
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBox), new PropertyMetadata(null));


    }
}
