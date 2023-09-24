using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        public List<EventViewModel> events { get; set; } = new List<EventViewModel>();
    }
}
