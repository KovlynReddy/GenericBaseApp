using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class BaseViewModel 
    {
        public string Theme { get; set; }
        public SettingsImplementationViewModel settings { get; set; }
    }
}
