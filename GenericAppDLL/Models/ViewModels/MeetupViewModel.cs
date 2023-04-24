using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class MeetupViewModel
    {
        public string SenderGuid { get; set; }
        public string RecieverGuid { get; set; }
        public string Lat { get; set; }
        public string lon { get; set; }
        public string DateTimeSent { get; set; }
        public string DateTimeRecieved { get; set; }
        public string DateTimeResponded { get; set; }

        public int Status { get; set; }
        public string Caption { get; set; }
        public string ModelGuid { get; set; }
    }
}
