using AutoMapper;
using GenericBaseMVC.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers
{
    public class MeetupRequestController : Controller
    {
        public IMapper Mapper { get; }
        public IHubContext<MeetHub> Hub { get; }
        public MeetUpService _meetupService { get; set; }
        public MeetupRequestService _meetupRequestService { get; set; }

        public MeetupRequestController(IMapper mapper, IHubContext<MeetHub> hub)
        {
            Mapper = mapper;
            Hub = hub;
            _meetupService = new MeetUpService();
            _meetupRequestService = new MeetupRequestService();
        }
        public async Task<IActionResult> ViewAll()
        {
            var model = new ViewListMeetupRequests();
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var results = await _meetupRequestService.Get();
            model.settings = await SettingsHandler.GetSettings(email);

            model.meetups = Mapper.Map<List<MeetupViewRequestModel>>(results.ToList());

            return View("MeetupReqestListView",model);
        }

        [HttpGet]
        public async Task<IActionResult> Accept(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            var dto = new MeetupRequestDto() { 
            SenderGuid = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            MeetupGuid = id,
            SenderName = currentCustomer.CustomerName,
            SentDateTime = DateTime.Now.ToString(),
            Status = 1,
            Description = "",
            Caption = "",
            CreatedDateTime = DateTime.Now,
            };

            await _meetupRequestService.Put(dto);

            return RedirectToAction(actionName:"Create",controllerName:"MeetUp");
        }

        [HttpGet]
        public async Task<IActionResult> Deny(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            var dto = new MeetupRequestDto()
            {
                SenderGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                MeetupGuid = id,
                SenderName = currentCustomer.CustomerName,
                SentDateTime = DateTime.Now.ToString(),
                Status = 1,
                Description = "",
                Caption = "",
                CreatedDateTime = DateTime.Now,
            };

            await _meetupRequestService.Put(dto);

            return RedirectToAction(actionName: "Create", controllerName: "MeetUp");
        }

        public async Task<IActionResult> Get(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Post(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            var dto = new CreateMeetupRequestDto()
            {
                SenderGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                MeetupGuid = id,
                SenderName = currentCustomer.CustomerName,
                SentDateTime = DateTime.Now.ToString(),
                Status = 1,
                Description = "",
                Caption = "",
                CreatedDateTime = DateTime.Now,
            };

            await _meetupRequestService.Post(dto);

            var points = new PointsDto()
            {
                AccountGuid = currentCustomer.AccountGuid,
                Description = "Viewed Post",
                Type = 5,
                SenderType = 4,
                UserGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                Amount = 1,
                CreatedDateTime = DateTime.Now.ToString(),
            };

            await new PointsService().Post(points);

            await SendMeetRequest(new SignalRMeet());

            return RedirectToAction("Create","MeetUp");
        }
        public async Task<IActionResult> Put()
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            return View();
        }

        public async Task<IActionResult> SendMeetRequest(SignalRMeet Message)
        {
            await Hub.Clients.All.SendAsync("MeetupRequestRecieved", Message);
            return Ok();
        }
    }
}
