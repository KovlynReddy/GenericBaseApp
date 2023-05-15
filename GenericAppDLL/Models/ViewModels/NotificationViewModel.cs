using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        public string Heading { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
    }
}
