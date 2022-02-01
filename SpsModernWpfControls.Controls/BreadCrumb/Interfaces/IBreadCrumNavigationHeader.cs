using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpsModernWpfControls.Controls.BreadCrumb.Interfaces
{
    public interface IBreadCrumbNavigationHeader
    {
        string Caption { get; set; }
        object Image { get; set; }
        string Tooltip { get; set; }
    }
}
