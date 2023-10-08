using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string SelectedMenu { get; set; } = "Side";
        public IFormFile newProfile { get; set; }
        public ThemeControlViewModel Themes { get; set; } = new ThemeControlViewModel();
    }
}
