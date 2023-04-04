using GenericBaseMVC.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers;

public class ChatController : Controller
{
    public IHubContext<MessageHub> _hub { get; set; }

    public ChatController(IHubContext<MessageHub> hub)
    {      
        _hub = hub;
    }

    public IActionResult Index()
    {
        var model = new ChatViewModel();
        var userEmail = User.Identity.Name;

        
        model.AllMessages = new List<DirectMessageViewModel>();
        model.OtherChatHeads = new List<ChatHeaderViewModel>();

        for (int i = 1; i < 10; i++)
        {
            var tempMessage = new DirectMessageViewModel()
            {
                SenderGUID = userEmail,
                Message = "Send Message ...",
                SenderId = 91+ i,
                ReaderGUID = "Test Guid " + i,
                ReaderId = 99 + i
            };

            var tempHeader = new ChatHeaderViewModel()
                {
                    RecieverName = "Test Chat 0" + i,
                    ChatId = 222 + i,
                    CreatorId = 111 + i,
                    Id = 999 + i,
                    ProfilePicturePath = $"TestImage{i}.png"
                };

            model.AllMessages.Add(tempMessage);
            model.OtherChatHeads.Add(tempHeader);
        }

        model.NewMessage = new SendDirectMessageViewModel() {
            SenderGuid = userEmail,
            Message = "Send Message ...",
            SenderId = 91,
            RecieverGuid = "Test Guid",
            RecieverId = 99
        };
        model.ChatHead = new ChatHeaderViewModel() { 
            RecieverName = "Test Chat 01",
            ChatId = 222,
            CreatorId = 111,
            Id = 999,
            ProfilePicturePath = "TestImage.png"
        };

        return View("AllMyChats", model);
    }

    public async Task<IActionResult> Get()
    {
        var model = new ChatViewModel();
        var userEmail = User.Identity.Name;
        
        await DirectMessageService.Get(userEmail);
        await ChatService.Get(userEmail);

        return View("AllMyChats",model);
    }

    [HttpPost]
    public async Task<IActionResult> SendDirectMessage(SendDirectMessageViewModel model)
    {

        //await ChatService.Create(model);

        var SRMessage = new SignalRMessage()
        {
            Message = model.Message,
            UserId = model.SenderId,
            MeetingId = model.RecieverId
        };

        await SendAMessage(SRMessage);

        return RedirectToAction("AttendMeeting", model.RecieverId);
    }

    public async Task<IActionResult> SendAMessage(SignalRMessage Message)
    {
        await _hub.Clients.All.SendAsync("RecieveMessage", Message);
        return View();
    }

}
