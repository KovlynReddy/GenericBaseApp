namespace GenericBaseMVC.Controllers;

public class BookingController : Controller
{
    public BookingService _bookingService { get; set; }
    public BookingController()
    {
        _bookingService = new BookingService();
    }
    // GET: BookingController
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Schedule()
    {

        ViewData["events"] = new[]
        {
            new SchedulerDataDto { Id = 1, Title = "Customer 1 HairCut", Start_Date = "2022-11-14"},
            new SchedulerDataDto { Id = 2, Title = "Customer 2 Meeting", Start_Date = "2022-11-12"},
        };


        return View();
    }


    // GET: BookingController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll() {

        List<BookingDto> response = new List<BookingDto>();

        response = await _bookingService.GetAll();

        List<BookingViewModel> model = new List<BookingViewModel>();
       
        foreach (var booking in response)
        {
            model.Add(new BookingViewModel
            {
                BookDateTimeString = booking.BookDateTimeString,
                CreatedDateTimeString = booking.CreatedDateTimeString,
                ModelGuid = booking.ModelGuid,
                BarberGuid = booking.BarberGuid,
                UserGuid = booking.UserGuid
            });
        }

        return View("ViewListBookings",model);
    }

    // GET: BookingController/Create
    public ActionResult Create()
    {
        CreateBookingViewModel model = new CreateBookingViewModel();
        model.Barbers = new List<string> { 
        "Barber1","Barber2"
        };
        return View(model);
    }

    // POST: BookingController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateBookingViewModel newBooking)
    {
        CreateBookingDto newBookingDto = new CreateBookingDto
        {
            Reason = newBooking.Reason,
            BookDateTime = newBooking.BookingDateTime,
            BookDateTimeString = newBooking.BookingDateTime.ToString(),
            CreatedDateTime = DateTime.Today,
            CreatedDateTimeString = DateTime.Today.ToString(),
            Code = "01" ,
            Description =  newBooking.Description ,
            BookingDateTime = newBooking.BookingDateTime,
            BookingDate = newBooking.BookingDateTime,
            BarberGuid = newBooking.SelectedBarber,
            BookingTime = newBooking.BookingDateTime,
            ModelGuid = new Guid().ToString(),
            UserGuid = User.Identity.Name,
            Request = newBooking.Request
        };

        try
        {
            _bookingService.Create(newBookingDto);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BookingController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: BookingController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BookingController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BookingController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
