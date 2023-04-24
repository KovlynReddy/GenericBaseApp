using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public CustomerViewModel profileDetails { get; set; }
    }
}
