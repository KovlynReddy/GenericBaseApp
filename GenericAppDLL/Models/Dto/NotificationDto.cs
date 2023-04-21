using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class NotificationDto
    {   
        public string ReaderGuid { get; set; }   = string.Empty;
        public string SenderGuid { get; set; }   = string.Empty;
        public string EntityGuid { get; set; }   = string.Empty;
        public string ReadDateTime { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string SentDateTime { get; set; } = string.Empty;
        public string Caption { get; set; }      = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
