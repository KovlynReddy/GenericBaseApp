using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ChatViewModel
    {
        public List<DirectMessageViewModel> AllMessages { get; set; } = new List<DirectMessageViewModel>();
        public SendDirectMessageViewModel NewMessage { get; set; } 
        public ChatHeaderViewModel ChatHead { get; set; }
        public List<ChatHeaderViewModel> OtherChatHeads { get; set; } = new List<ChatHeaderViewModel>();
    }
}
