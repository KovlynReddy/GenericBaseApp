using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ManageVendorMenuViewModel : BaseViewModel
    {
        public VendorViewModel VendorDetails { get; set; }
        public List<MenuItemViewModel> menu { get; set; } = new List<MenuItemViewModel>();
    }
}
