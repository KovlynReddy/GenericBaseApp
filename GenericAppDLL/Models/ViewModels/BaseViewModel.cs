using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class BaseViewModel 
    {
        public SettingsImplementationViewModel settings { get; set; } = new SettingsImplementationViewModel();
        public AdvertisingHelper advertising { get; set; } = new AdvertisingHelper();
    }
}
