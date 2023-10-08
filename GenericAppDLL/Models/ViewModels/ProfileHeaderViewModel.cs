using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ProfileHeaderViewModel : BaseViewModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string SelectedTheme { get; set; } = string.Empty;
        public string ProfileImagePath { get; set; } = string.Empty;
        public string UserId { get; set; }
    }
}
