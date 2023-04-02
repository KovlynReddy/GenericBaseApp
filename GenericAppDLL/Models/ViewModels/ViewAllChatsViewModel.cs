using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels;

public class ViewAllChatsViewModel
{
    public int ConversationId { get; set; }
    public int RecieverId { get; set; }
    public string UserName { get; set; }
    public List<DirectMessageViewModel> Messages { get; set; } = new List<DirectMessageViewModel>();
    public SendDirectMessageViewModel NewMessage { get; set; } = new SendDirectMessageViewModel();
    public List<ChatHeaderViewModel> OtherMeetings { get; set; } = new List<ChatHeaderViewModel>();
}
