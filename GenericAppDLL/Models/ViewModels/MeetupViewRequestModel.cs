using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class MeetupViewRequestModel : BaseViewModel
    {
        public string ReaderGuid { get; set; } = string.Empty;
        public string SenderGuid { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public string MeetupGuid { get; set; } = string.Empty;
        public string ReadDateTime { get; set; } = string.Empty;
        public int Status { get; set; }
        public string SentDateTime { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ModelGuid { get; set; } = string.Empty;
        public bool IsSender { get; set; }
        public string Message { get; set; }
    }
}
