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

    // GET: Bookings
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Bookings.ToListAsync());
    }

    [Route("~/api/Booking/GetAll")]
    [HttpGet("GetAll")]
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


    // GET: Bookings/Details/5
    [HttpGet("Details")]
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

    // GET: Bookings/Create
    [HttpPost("Create")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Bookings/Create
    //[AllowAnonymous]
    [Route("~/api/Booking/CreateDto")]
    [HttpPost("CreateDto")]
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
    [HttpPost("CreateMeeetupDto")]
    public async Task<ActionResult<CreateBookingDto>> CreateMeetupDto(CreateBookingDto newBookingDto)
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

    [HttpPatch("update/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VendorGuid,UserGuid,Reason,Rating,Description,BookingTime,ArriveTime,CompletionTime,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Booking booking)
    {
        if (id != booking.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(booking);
    }


    [HttpGet("GetCalendarData")]
    public async Task<IActionResult> GetCalendarData(){

        List<SchedulerDataDto> data = new List<SchedulerDataDto>();

       
        SchedulerDataDto infoObj1 = new SchedulerDataDto();
        infoObj1.Id = 1;
        infoObj1.Title = "User1 Cut";
        infoObj1.Desc = "Description 1";
        infoObj1.Start_Date = "2022-09-16 22:37:22.467";
        infoObj1.End_Date = "2022-09-16 23:30:22.467";
        data.Add(infoObj1);

        SchedulerDataDto infoObj2 = new SchedulerDataDto();
        infoObj2.Id = 2;
        infoObj2.Title = "User2 Cut";
        infoObj2.Desc = "Description 2";
        infoObj2.Start_Date = "2022-09-17 10:00:22.467";
        infoObj2.End_Date = "2022-09-17 11:00:22.467";
        data.Add(infoObj2);


        SchedulerDataDto infoObj3 = new SchedulerDataDto();
        infoObj3.Id = 3;
        infoObj3.Title = "Meeting";
        infoObj3.Desc = "Description 3";
        infoObj3.Start_Date = "2022-09-18 07:30:22.467";
        infoObj3.End_Date = "2022-09-18 08:00:22.467";
        data.Add(infoObj3);

        return Ok(data);
    }

    // HttpDelete: Bookings/Delete/5
    [HttpDelete("Delete")]
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

    // POST: Bookings/Delete/5
    [HttpDelete("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookingExists(int id)
    {
        return _context.Bookings.Any(e => e.Id == id);
    }
}
