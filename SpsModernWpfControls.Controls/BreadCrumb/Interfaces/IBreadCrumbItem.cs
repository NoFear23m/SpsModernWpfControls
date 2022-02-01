using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpsModernWpfControls.Controls.BreadCrumb.Interfaces
{
    public interface IBreadCrumbItem
{
    IBreadCrumbNavigationHeader Header { get; set; }
    object Content { get; set; }
    bool IsNavigatable { get; set; }
}
}
