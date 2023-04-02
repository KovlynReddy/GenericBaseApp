using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class DirectMessageViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int CreatorId { get; set; }
        public int ReaderId { get; set; }
        public int SenderId { get; set; }
        public int MeetingId { get; set; }
        public int ItemId { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
