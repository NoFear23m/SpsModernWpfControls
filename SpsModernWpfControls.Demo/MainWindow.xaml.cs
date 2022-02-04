using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SpsModernWpfControls.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestProp = "Init";
            this.DataContext = this;
        }

        private string testProp;
        public string TestProp
        {
            get { return testProp; }
            set { testProp = value; Debug.WriteLine("Prop set: " + value); }
        }


        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null) { save = new RelayCommand(Save_Execute, Save_CanExecute); }
                return save;
            }
        }
        private void Save_Execute(object obj)
        {
            //MessageBox.Show("Save new value " + obj.ToString());
        }

        private bool Save_CanExecute(object obj)
        {
            return true;
        }


    }
}
