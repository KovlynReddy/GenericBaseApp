using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class SettingsImplementationViewModel
    {
        public string SelectedTheme { get; set; }
        public int NumNotifcations { get; set; }

        public List<SideAdvertViewModel> sideAdverts { get; set; } = new List<SideAdvertViewModel>();
    }
}
