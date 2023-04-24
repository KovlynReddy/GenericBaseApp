using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewListAddressViewModel : BaseViewModel
    {
        public List<AddressViewModel> addresses { get; set; } = new List<AddressViewModel>();
    }
}
