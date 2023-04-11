using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ShopDashboardViewModel
    {
        public List<VendorViewModel> AllVendors { get; set; } =  new List<VendorViewModel>();
        public List<MenuItemViewModel> AllMenuItems { get; set; } = new List<MenuItemViewModel>();
    }
}
