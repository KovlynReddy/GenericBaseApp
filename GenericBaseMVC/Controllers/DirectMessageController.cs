using GenericBaseMVC.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers
{
    public class DirectMessageController : Controller
    {
        public IHubContext<MessageHub> _hub { get; set; }

        public DirectMessageController(IHubContext<MessageHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            var allMessages = await DirectMessageService.Get(Id);

            return View(allMessages);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SendDirectMessageViewModel model)
        {

            await DirectMessageService.Post(model);

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
}
