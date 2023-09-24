using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class HubViewModel : BaseViewModel
    {
        public List<SideAdvertViewModel> adverts { get; set; } = new List<SideAdvertViewModel>();
    }
}
