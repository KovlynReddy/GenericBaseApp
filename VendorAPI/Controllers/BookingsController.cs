namespace VendorAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BookingsController : Controller
{
    private readonly VendorContext _context;

    public BookingsController(VendorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Bookings.ToListAsync());
    }

    [Route("~/api/Booking/GetAll")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allBookings = await _context.Bookings.ToListAsync();
        List<BookingDto> allBookingDtos = new List<BookingDto>();

        foreach (var booking in allBookings)
        {
            allBookingDtos.Add(new BookingDto {
                BookDateTimeString = booking.BookingTime,
                CreatedDateTimeString = booking.CreatedDateTime,
                ModelGuid = booking.ModelGUID,
                VendorGuid = booking.VendorGuid,
                UserGuid = booking.UserGuid
            });
        }

        return Ok(allBookingDtos);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings
            .FirstOrDefaultAsync(m => m.Id == id);
        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    // POST: Bookings/Create
    //[AllowAnonymous]
    [Route("~/api/Booking")]
    [HttpPost]
    public async Task<IActionResult> CreateDto([FromBody] CreateBookingDto newBookingDto)
    {
        Booking newBooking = new Booking
        {
            Reason = newBookingDto.Reason,
            BookingTime = newBookingDto.BookDateTime.ToString(),
            ModelGUID = new Guid().ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            Rating = 0,
            Description = newBookingDto.Description,
            VendorGuid = newBookingDto.VendorGuid,
            UserGuid = newBookingDto.UserGuid,
            CreatorId = newBookingDto.UserGuid
        };
        _context.Add(newBooking);
        await _context.SaveChangesAsync();
        return Ok(newBooking);
    }

    [Route("~/api/Booking/CreateMeeetupDto")]
    [HttpPost]
    public async Task<ActionResult<CreateBookingDto>> CreateMeetupDto([FromBody] CreateBookingDto newBookingDto)
    {
        Booking newBooking = new Booking
        {
            Reason = newBookingDto.Reason,
            BookingTime = newBookingDto.BookDateTime.ToString(),
            ModelGUID = new Guid().ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            Rating = 0,
            Description = newBookingDto.Description,
            VendorGuid = newBookingDto.VendorGuid,
            UserGuid = newBookingDto.UserGuid,
            CreatorId = newBookingDto.UserGuid
        };
        _context.Add(newBooking);
        await _context.SaveChangesAsync();
        return Ok(newBooking);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings
            .FirstOrDefaultAsync(m => m.Id == id);
        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    private bool BookingExists(int id)
    {
        return _context.Bookings.Any(e => e.Id == id);
    }
}
