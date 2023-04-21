using AutoMapper;
using GenericBaseMVC.Handlers;

namespace GenericBaseMVC.Controllers;

public class ProfileController : Controller
{

    public VendorService _VendorService { get; set; }
    public CustomerService _customerService { get; set; }
    public AddressService _addressService { get; set; }
    public BookingService _bookingService { get; set; }
    public RelationshipService _relationshipService { get; set; }
    public ProfileHandler _profileHandler { get; set; }
    public IMapper Mapper { get; }


    public ProfileController(IMapper mapper)
    {
        _addressService = new AddressService();
        _customerService = new CustomerService();
        _VendorService = new VendorService();
        _bookingService = new BookingService();
        _relationshipService = new RelationshipService();
        _profileHandler = new ProfileHandler(mapper);
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
        var model = await _profileHandler.ViewFriendRequests(email);

        return View(model); 
       
    }    
    
    [HttpPost]
    public async Task<IActionResult> ViewProfile(CustomerViewModel email)
    {
        var model = await GetCustomerProfile(email.ModelGUID); 

        return View("ViewProfile",model); 
       
    }    
    
    [HttpGet]
    public async Task<IActionResult> AcceptFriendRequest(string id)
    {
        var relationship = await _profileHandler.RespondToFriendRequest(id, 2);

        return RedirectToAction("ViewFriendRequests");
    }    
    
    [HttpGet]
    public async Task<IActionResult> DeclineFriendRequest(string id)
    {
        var relationship = await _profileHandler.RespondToFriendRequest(id, 3);

        return RedirectToAction("ViewFriendRequests");

    }

    [HttpGet]
    public async Task<IActionResult> SendFriendRequest(string id)
    {
        var email = User.Identity.Name;
        var model = await _profileHandler.SendFriendRequest(id,email);



        return View("ViewProfile", model);

    }

    public async Task<IActionResult> Index()
    {
        var email = User.Identity.Name;
        var model = await _profileHandler.GetAllProfiles(email);

        return View(model);
    }
}
