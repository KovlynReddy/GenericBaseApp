using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ChatHeaderViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string RecieverName { get; set; } = string.Empty;
        public string ChatId { get; set; }
        public string ProfilePicturePath { get; set; }
        public string LastMessage { get; set; }
        public string LastMessageSent { get; set; }
    }
}
