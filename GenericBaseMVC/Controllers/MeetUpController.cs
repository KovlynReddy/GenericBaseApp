using AutoMapper;
using GenericBaseMVC.Hubs;
using GenericBaseMVC.Services;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers;

public class MeetUpController : Controller
{
    public IMapper Mapper { get; }
    public IHubContext<MeetHub> Hub { get; }
    public MeetUpService _meetupService { get; set; }

    public MeetUpController(IMapper mapper, IHubContext<MeetHub> hub)
    {
        Mapper = mapper;
        Hub = hub;
        _meetupService = new MeetUpService();
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Schedule()
    {

        return View();
    }  


    [HttpGet]
    public async Task<IActionResult> ViewAll()
    {

        return View();
    }    


    [HttpGet]
    public async Task<IActionResult> AttendMeetUp(string id)
    {

        return View();
    }


    [HttpGet]
    public async Task<IActionResult> RespondToInvite(string id)
    {

        return View();
    }
        
    [HttpGet]
    public async Task<IActionResult> Accept(string id)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

        var meetups = await _meetupService.Respond(new MeetupResponseDto() { id = id,response = 0, responderId = currentCustomer.ModelGuid}) ;
        return View();
    }
        
    
    [HttpGet]
    public async Task<IActionResult> Deny(string id)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

        var meetups = await _meetupService.Respond(new MeetupResponseDto() { id = id, response = 1 , responderId = currentCustomer.ModelGuid });
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string slat , string slon) {

        var model = new CreateMeetupMapViewModel();

        var meetups = await _meetupService.Get();

        var cords = meetups.Select(m=>(m.Lat,m.lon)).ToList();
        var lats = meetups.Select(m=>m.Lat).Select(m=>m.Replace('(', ' ').Replace(')', ' ')).ToList();
        var lons = meetups.Select(m=>m.lon).Select(m=>m.Replace('(', ' ').Replace(')', ' ')).ToList();
        var captions = meetups.Select(m=>m.Caption).ToList();
        var meetupIds = meetups.Select(m=>m.ModelGuid).ToList();

        model.ids = meetupIds;
        model.newMeetup.ListPeople = cords;
        model.Lats = lats;
        model.Longs = lons;
        model.Captions = captions;
        model.CenterLat = slat.Replace(',', '.').ToString();
        model.CenterLon = slon.Replace(',', '.').ToString();


        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

        return View("_MeetupMapView", model);
    }

    [HttpGet]
    public async Task<IActionResult> SuggestedMeetup()
    {
        var model = new CreateMeetupMapViewModel();

        return View("SuggestedMeetup", model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateFromCurrentLocation(string slat, string slon)
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateMeetupMapViewModel model)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

        var dto = Mapper.Map<CreateMeetUpDto>(model.newMeetup);
        dto.SenderGuid = currentCustomer.ModelGuid;
        dto.DateTimeSent = DateTime.Now.ToString();
        dto.ModelGuid = Guid.NewGuid().ToString();

        var results = await _meetupService.Create(dto);

        var points = new PointsDto()
        {
            AccountGuid = currentCustomer.AccountGuid,
            Description = "Meetup Created",
            Type = 6,
            SenderType = 7,
            UserGuid = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            Amount = 30,
            CreatedDateTime = DateTime.Now.ToString(),            
        };

        await new PointsService().Post(points);

        await SendMeetRequest(new SignalRMeet());

        return RedirectToAction("Create", "MeetUp");
    }

    public async Task<IActionResult> SendMeetRequest(SignalRMeet Message)
    {
        await Hub.Clients.All.SendAsync("MeetupRequestRecieved", Message);
        return Ok();
    }
}
