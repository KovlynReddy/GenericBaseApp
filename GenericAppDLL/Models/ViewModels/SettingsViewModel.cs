using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public int Model { get; set; }
        public IFormFile newProfile { get; set; }
        public ThemeControlViewModel Themes { get; set; } = new ThemeControlViewModel();
    }
}
