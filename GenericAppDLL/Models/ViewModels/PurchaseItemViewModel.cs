using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class PurchaseItemViewModel : BaseViewModel
    {
        public string DatePurchased { get; set; } = string.Empty;
        public string ItemGuid { get; set; } = string.Empty;
        public string VendorGuid { get; set; } = string.Empty;
        public string CartId { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int IsPaid { get; set; }
        public string ModelGuid { get; set; } = string.Empty;
        public int Cost { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
    }
}
