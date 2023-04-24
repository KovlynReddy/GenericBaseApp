using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class SuggestedItemViewModel : BaseViewModel
    {
        public List<VendorViewModel> vendors { get; set; }
    }
}
