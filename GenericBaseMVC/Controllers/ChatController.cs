using ChilliSoftAssessmentMeetingMinuteTakerMVC.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers;

public class ChatController : Controller
{

    public IHubContext<MeetingHub> _hub { get; set; }
    public ChatController(IHubContext<MeetingHub> hub)
    {
        _hub = hub;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AllMyChats()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendDirectMessage(SendDirectMessageViewModel model)
    {

        //await ChatService.Create(model);

        var SRMessage = new SignalRMessage()
        {
            Message = model.Message,
            UserId = model.SenderId,
            ItemId = model.ItemId,
            MeetingId = model.MeetingId
        };

        await SendAMessage(SRMessage);

        return RedirectToAction("AttendMeeting", model.MeetingId);
    }

    public async Task<IActionResult> SendAMessage(SignalRMessage Message)
    {
        await _hub.Clients.All.SendAsync("RecieveMessage", Message);
        return View();
    }

}
