using AutoMapper;

namespace VendorAPI.Controllers;

[Route("api/MeetUp")]
[ApiController]
public class MeetUpController : Controller
{
    private readonly VendorContext _context;
    private readonly IMapper mapper;

    public MeetUpController(VendorContext context,IMapper mapper)
    {
        _context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    [Route("~/api/MeetUp/{id}")]
    public IActionResult Get(string id)
    {

        var AllMeetUps = _context.MeetUps.ToList();

        List<MeetUpDto> allMeetups = mapper.Map<List<MeetUpDto>>(AllMeetUps);

        return Ok(allMeetups);
    }

    [HttpGet]
    [Route("~/api/MeetUp")]
    public IActionResult Get()
    {
        var AllMeetUps = _context.MeetUps.ToList();

        List<MeetUpDto> allMeetups = mapper.Map<List<MeetUpDto>>(AllMeetUps);

        return Ok(allMeetups);
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
    [Route("~/api/MeetUp")]
    public async Task<IActionResult> Post(CreateMeetUpDto newInvite)
    {
        var entity = mapper.Map<Meetup>(newInvite);
        _context.Add(entity);

        _context.SaveChanges();

        return Ok();
    }
}
