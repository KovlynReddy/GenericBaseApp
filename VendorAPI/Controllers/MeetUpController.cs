namespace VendorAPI.Controllers;

[Route("api/MeetUp")]
[ApiController]
public class MeetUpController : Controller
{
    private readonly VendorContext _context;

    public MeetUpController(VendorContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("~/api/MeetUp/GetAll")]
    public IActionResult GetAll()
    {

        var AllMeetUps = _context.MeetUps.ToList();

        List<MeetUpDto> allMeetups = new List<MeetUpDto>();

        foreach (var meetup in AllMeetUps)
        {
            MeetUpDto meetUpDto = new MeetUpDto() { 
            Lat = meetup.Lat
            };

            allMeetups.Add(meetUpDto);
        }



        return Ok(allMeetups);
    }

    [HttpGet]
    [Route("~/api/MeetUp/Get")]
    public IActionResult Get()
    {
        return View();
    }

    [HttpPost]
    [Route("~/api/MeetUp/Respond")]
    public IActionResult Respond(CreateMeetUpDto newInvite)
    {
        Meetup invite = new Meetup()
        {

        };

        _context.Update(invite);
        _context.SaveChanges();

        return View();
    }

    [HttpPost]
    [Route("~/api/MeetUp/CreateDto")]
    public IActionResult CreateDto(CreateMeetUpDto newInvite)
    {
        Meetup invite = new Meetup() { 
        
        };

        _context.Add(invite);

        _context.SaveChanges();

        return View();
    }
}
