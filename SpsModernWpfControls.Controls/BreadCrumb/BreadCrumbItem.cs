using SpsModernWpfControls.Controls.BreadCrumb.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpsModernWpfControls.Controls.BreadCrumb
{

    public class BreadCrumbItem : INotifyPropertyChanged, IBreadCrumbItem
    {
        public BreadCrumbItem() : this(new BreadCrumbNavigationHeader() { Caption = "Header", Tooltip = "Tooltip" }, "Content")
        {
        }


        public BreadCrumbItem(IBreadCrumbNavigationHeader header, object content)
        {
            this.Header = header;
            this.Content = content;
            IsNavigatable = true;
        }


        private IBreadCrumbNavigationHeader _header;
        public IBreadCrumbNavigationHeader Header
        {
            get
            {
                return _header;
            }
            set
            {
                _header = value;
                RaisePropertyChanged();
            }
        }

        private object _content;
        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                RaisePropertyChanged();
            }
        }

        private bool _isNavigatable;
        public bool IsNavigatable
        {
            get
            {
                return _isNavigatable;
            }
            set
            {
                _isNavigatable = value;
                RaisePropertyChanged();
            }
        }


        private bool _hasPreviousItems = true;

        public bool HasPreviousItems
        {
            get
            {
                return _hasPreviousItems;
            }
            set
            {
                _hasPreviousItems = value;
                RaisePropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
