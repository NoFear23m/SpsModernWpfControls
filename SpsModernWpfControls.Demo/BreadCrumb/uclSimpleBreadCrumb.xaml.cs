using SpsModernWpfControls.Controls.BreadCrumb;
using SpsModernWpfControls.Controls.BreadCrumb.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpsModernWpfControls.Demo.BreadCrumb
{
    /// <summary>
    /// Interaktionslogik für uclSimpleBreadCrumb.xaml
    /// </summary>
    public partial class uclSimpleBreadCrumb : UserControl
    {
        public uclSimpleBreadCrumb()
        {
            InitializeComponent();
 BreadItems = new ObservableCollection<IBreadCrumbItem>
            {
                new BreadCrumbItem(new BreadCrumbNavigationHeader() { Caption = "Header from Code 1" }, "Content from Code 1"),
                new BreadCrumbItem(new BreadCrumbNavigationHeader() { Caption = "Header from Code 2" }, "Content from Code 2"),
                new BreadCrumbItem(new BreadCrumbNavigationHeader() { Caption = "Header from Code 3" }, "Content from Code 3"),
                new BreadCrumbItem(new BreadCrumbNavigationHeader() { Caption = "Header from Code 4" }, "Content from Code 4")
            };
            this.Loaded += Window_Loaded;
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private ObservableCollection<IBreadCrumbItem> breadItems;
        public ObservableCollection<IBreadCrumbItem> BreadItems
        {
            get { return breadItems; }
            set { breadItems = value; }
        }



    }
}
