using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {
        public int NumNotifcations { get; set; }
        public List<NotificationViewModel> notifications { get; set; } = new List<NotificationViewModel>();
    }
}
