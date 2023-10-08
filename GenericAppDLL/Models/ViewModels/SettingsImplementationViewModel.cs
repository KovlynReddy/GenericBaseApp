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
        public string SelectedMenu { get; set; } = "Side";
        public int NumNotifcations { get; set; }

        public bool EnableSideAdvert { get; set; } = false;
        public List<SideAdvertViewModel> sideAdverts { get; set; } = new List<SideAdvertViewModel>();
    }
}
