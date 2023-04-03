using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ChatHeaderViewModel
    {
        public string MeetingType { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int CreatorId { get; set; }
        public string MeetingName { get; set; } = string.Empty;
        public int MeetingTypeId { get; set; }
        public string MeetingTypeGuid { get; set; } = string.Empty;
        public int MeetingStatus { get; set; }
        public string MeetingGuid { get; set; } = string.Empty;
    }
}
