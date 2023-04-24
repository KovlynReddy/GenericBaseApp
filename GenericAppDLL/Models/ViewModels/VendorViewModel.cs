using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class VendorViewModel : BaseViewModel
    {
        public List<MenuItemViewModel> AllVendorItems { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public string VendorEmail { get; set; } = string.Empty;
        public string AddressGuid { get; set; } = string.Empty;
        public string AverageRating { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; } = string.Empty;
        public string ModelGUID { get; set; } = string.Empty;
        public int Status { get; set; }
        public int IsMod { get; set; }
        public int Id { get; set; }

    }
}
