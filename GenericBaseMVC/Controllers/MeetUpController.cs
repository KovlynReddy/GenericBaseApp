namespace GenericBaseMVC.Controllers;

public class MeetUpController : Controller
{
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

        var model = new MapViewModel();
        return View("_MapView", model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateFromCurrentLocation(string slat, string slon)
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMeetUpViewModel model)
    {

        return View();
    }
}
