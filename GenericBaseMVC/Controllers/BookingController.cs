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

        var model = new ViewListBookingViewModel();
        List<BookingDto> response = new List<BookingDto>();

        response = await _bookingService.GetAll();

        List<BookingViewModel> bookings = new List<BookingViewModel>();
       
        foreach (var booking in response)
        {
            bookings.Add(new BookingViewModel
            {
                BookDateTimeString = booking.BookDateTimeString,
                CreatedDateTimeString = booking.CreatedDateTimeString,
                ModelGuid = booking.ModelGuid,
                VendorGuid = booking.VendorGuid,
                UserGuid = booking.UserGuid
            });
        }
        model.bookings = bookings;
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings.SelectedTheme = currentCustomer.SelectedTheme;

        return View("ViewListBookings",model);
    }

    // GET: BookingController/Create
    public async Task<ActionResult> Create()
    {
        CreateBookingViewModel model = new CreateBookingViewModel();
        model.Vendors = new List<string> { 
        "Vendor1","Vendor2"
        };
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings.SelectedTheme = currentCustomer.SelectedTheme;
        return View(model);
    }

    // POST: BookingController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateBookingViewModel newBooking)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

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
            VendorGuid = newBooking.SelectedVendor,
            BookingTime = newBooking.BookingDateTime,
            ModelGuid = new Guid().ToString(),
            UserGuid = User.Identity.Name,
            Request = newBooking.Request
        };

        try
        {
            _bookingService.Create(newBookingDto);

            var points = new PointsDto()
            {
                AccountGuid = currentCustomer.AccountGuid,
                Description = "Post Created",
                Type = 1,
                SenderType = 1,
                UserGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                Amount = 150,
                CreatedDateTime = DateTime.Now.ToString(),
            };

            await new PointsService().Post(points);

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
