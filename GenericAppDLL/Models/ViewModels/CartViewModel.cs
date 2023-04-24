using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public string CartId { get; set; } = string.Empty;
        public List<PurchaseItemViewModel> purchasedItems { get; set; } = new List<PurchaseItemViewModel>();
        public List<PurchaseViewModel> purchases { get; set; } = new List<PurchaseViewModel>();
        public List<MenuItemViewModel> Items { get; set; } = new List<MenuItemViewModel>();
    }
}
