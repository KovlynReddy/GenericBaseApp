using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ThemeControlViewModel
    {
        public List<ThemeViewModel> Themes { get; set; }
        public string SelectedTheme { get; set; } = string.Empty;
    }
}
