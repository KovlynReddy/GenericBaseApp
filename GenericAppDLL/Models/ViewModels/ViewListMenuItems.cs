using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewListMenuItems : BaseViewModel
    {
        public List<MenuItemViewModel> items { get; set; } = new List<MenuItemViewModel>();
    }
}
