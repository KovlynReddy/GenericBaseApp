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
    public async Task<IActionResult> Create() {

        var model = new CreateMeetupMapViewModel();

        var meetups = await _meetupService.Get();

        var cords = meetups.Select(m=>(m.Lat,m.lon)).ToList();
        var lats = meetups.Select(m=>m.Lat).Select(m=>m.Replace('(', ' ').Replace(')', ' ')).ToList();
        var lons = meetups.Select(m=>m.lon).Select(m=>m.Replace('(', ' ').Replace(')', ' ')).ToList();
        var captions = meetups.Select(m=>m.Caption).ToList();
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

        var results = await _meetupService.Create(dto);

            return View();
    }
}
