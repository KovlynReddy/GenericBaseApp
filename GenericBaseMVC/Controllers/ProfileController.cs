namespace GenericBaseMVC.Controllers;

public class ProfileController : Controller
{

    public VendorService _VendorService { get; set; }
    public CustomerService _customerService { get; set; }
    public AddressService _addressService { get; set; }
    public BookingService _bookingService { get; set; }

    public ProfileController()
    {
        _addressService = new AddressService();
        _customerService = new CustomerService();
        _VendorService = new VendorService();
        _bookingService = new BookingService();
    }

    [HttpGet]
    public IActionResult CreateProfile() {

        return View();
    }

    [HttpGet]
    public IActionResult ViewAll()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateCustomerViewModel model)
    {
        // var results = await _customerService.GetAll();
        CreateBookingDto testBooking = new CreateBookingDto() { 
        Description = "sad",
        Reason = "dw",
        Code = "dsd"
        
        };

        //await _bookingService.Create(testBooking);


         CreateCustomerDto newUser = new CreateCustomerDto() { 
        CustomerEmail = model.CustomerEmail , 
        CustomerName = model.CustomerName,
        DOB = model.DOB.ToString(), 
       // UploadedImage = model.UploadedImage
        };

        await _customerService.Post(newUser);

        return View();
    }


    [HttpGet]
    public async Task<IActionResult> ViewProfile()
    {
        #region Temp Loggin

        string Email = "kovlyn.reddy01@gmail.com";
        var results = await _customerService.Get();
        var model = new List<CustomerViewModel>();

        foreach (var customer in results)
        {
            var customerVM = new CustomerViewModel()
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                ModelGUID = customer.ModelGuid
            };

            model.Add(customerVM);


        }

        var MyProfile = model.FirstOrDefault(m => m.CustomerEmail == Email);


        return View(MyProfile); 
        #endregion
    }

    [HttpPost]
    public async Task<IActionResult> ViewProfile(string Email)
    {
        var results = await _customerService.Get();
        var model = new List<CustomerViewModel>();

        foreach (var customer in results)
        {
            var customerVM = new CustomerViewModel()
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                ModelGUID = customer.ModelGuid
            };

            model.Add(customerVM);


        }

        var MyProfile = model.FirstOrDefault(m=>m.CustomerEmail==Email);


        return View(MyProfile);
    }

        public async Task<IActionResult> Index()
    {
        var results = await _customerService.Get();
        var model = new List<CustomerViewModel>();

        foreach (var customer in results)
        {
            var customerVM = new CustomerViewModel()
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                ModelGUID = customer.ModelGuid
            };

            model.Add(customerVM);


        }

        return View(model);
    }
}
