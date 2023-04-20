using AutoMapper;

namespace GenericBaseMVC.Controllers;

public class ProfileController : Controller
{

    public VendorService _VendorService { get; set; }
    public CustomerService _customerService { get; set; }
    public AddressService _addressService { get; set; }
    public BookingService _bookingService { get; set; }
    public IMapper Mapper { get; }

    public ProfileController(IMapper mapper)
    {
        _addressService = new AddressService();
        _customerService = new CustomerService();
        _VendorService = new VendorService();
        _bookingService = new BookingService();
        Mapper = mapper;
    }

    public async Task<ProfileViewModel> GetCustomerProfile(string email) {
        ProfileViewModel model = new ProfileViewModel();

        var customerDetails =(await _customerService.Get(email)).FirstOrDefault();

        model.profileDetails = Mapper.Map<CustomerViewModel>(customerDetails);

        return model;
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
        var email = User.Identity.Name;
        var model = await GetCustomerProfile(email); 

        return View("ViewProfile",model); 
       
    }       
    
    [HttpGet]
    public async Task<IActionResult> ViewFriendRequests()
    {
        var email = User.Identity.Name;
        var model = await GetCustomerProfile(email); 

        return View("ViewProfile",model); 
       
    }    
    
    [HttpPost]
    public async Task<IActionResult> ViewProfile(CustomerViewModel email)
    {
        var model = await GetCustomerProfile(email.ModelGUID); 

        return View("ViewProfile",model); 
       
    }    
    
    [HttpPost]
    public async Task<IActionResult> AcceptFriendRequest(CustomerViewModel email)
    {
        var model = await GetCustomerProfile(email.ModelGUID); 

        return View("ViewProfile",model); 
       
    }    
    
    [HttpPost]
    public async Task<IActionResult> DeclineFriendRequest(CustomerViewModel email)
    {
        var model = await GetCustomerProfile(email.ModelGUID); 

        return View("ViewProfile",model); 
       
    }

    [HttpPost]
    public async Task<IActionResult> SendFriendRequest(CustomerViewModel email)
    {
        var model = await GetCustomerProfile(email.ModelGUID);

        return View("ViewProfile", model);

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
