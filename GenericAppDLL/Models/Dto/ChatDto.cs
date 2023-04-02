using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class ChatDto :BaseDto
    {
        public string MeetingName { get; set; } = string.Empty;
        public int MeetingTypeId { get; set; }
        public int MeetingStatus { get; set; }
    }
}
