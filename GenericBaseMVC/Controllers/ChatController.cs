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
        return View();
    }

    public async Task<IActionResult> Get()
    {
        //await DirectMessageService.Get();
        //await ChatService.Get();

        return View("AllMyChats");
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
