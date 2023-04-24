using GenericAppDLL.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class MeetingScheduleViewModel : BaseViewModel
    {
        public List<SchedulerDataDto> data { get; set; } = new List<SchedulerDataDto>();
    }
}
