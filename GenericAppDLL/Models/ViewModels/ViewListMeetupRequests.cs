using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewListMeetupRequests : BaseViewModel
    {
        public List<MeetupViewRequestModel> meetups { get; set; }
        public List<MeetupViewRequestModel> MyMeetings { get; set; }
        public List<MeetupViewRequestModel> MyMeetupRequests { get; set; }
    }
}
