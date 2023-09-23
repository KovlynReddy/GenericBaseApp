using AutoMapper;
using GenericBaseMVC.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers
{
    public class DirectMessageController : Controller
    {
        public IHubContext<MessageHub> _hub { get; set; }
        public IMapper _mapper { get; set; }

        public DirectMessageController(IHubContext<MessageHub> hub , IMapper mapper)
        {
            _hub = hub;
            _mapper = mapper;
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

            await DirectMessageService.Post(_mapper.Map<DirectMessageDto>(model));

            var SRMessage = new SignalRMessage()
            {
                Message = model.Message,
                SenderId = model.SenderGuid,
                RecieverId = model.RecieverGuid,
                Attachment = model.Attachment,
                Code = 102
            };

            await SendAMessage(SRMessage);
            return Ok();
            //return RedirectToAction("AttendMeeting", model.RecieverId);
        }

        public async Task<IActionResult> SendAMessage(SignalRMessage Message)
        {
            await _hub.Clients.All.SendAsync("RecieveMessage", Message);
            return Ok();
        }
    }
}
