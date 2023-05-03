using AutoMapper;
using GenericBaseMVC.Services;

namespace GenericBaseMVC.Controllers;

public class MeetUpController : Controller
{
    public IMapper Mapper { get; }
    public MeetUpService _meetupService { get; set; }

    public MeetUpController(IMapper mapper)
    {
        Mapper = mapper;
        _meetupService = new MeetUpService();
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll()
    {

        return View();
    }    
    
    [HttpGet]
    public async Task<IActionResult> Suggested()
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

    [HttpGet]
    public async Task<IActionResult> Create() {

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


        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings.SelectedTheme = currentCustomer.SelectedTheme;

        return View("_MeetupMapView", model);
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


        return View();
    }
}
