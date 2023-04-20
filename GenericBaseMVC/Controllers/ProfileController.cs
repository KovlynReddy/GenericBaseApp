using AutoMapper;

namespace GenericBaseMVC.Controllers;

public class ProfileController : Controller
{

    public VendorService _VendorService { get; set; }
    public CustomerService _customerService { get; set; }
    public AddressService _addressService { get; set; }
    public BookingService _bookingService { get; set; }
    public RelationshipService _relationshipService { get; set; }
    public IMapper Mapper { get; }

    public ProfileController(IMapper mapper)
    {
        _addressService = new AddressService();
        _customerService = new CustomerService();
        _VendorService = new VendorService();
        _bookingService = new BookingService();
        _relationshipService = new RelationshipService();
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
        var currentUser =(await _customerService.Get(email)).FirstOrDefault(); 
        var friendRequests = await _relationshipService.Get(currentUser.ModelGuid);
        var userProfiles = new List<CustomerDto>();
        var model = new ViewFriendRequestsViewModel();

        foreach (var relationship in friendRequests)
        {
            if (relationship.SenderId == currentUser.ModelGuid)
            {
                userProfiles.Add((await _customerService.Get(relationship.RecieverId)).FirstOrDefault());
            }
            else {
                userProfiles.Add((await _customerService.Get(relationship.SenderId)).FirstOrDefault());
            }
        }

        var userProfileVMs = Mapper.Map<List<CustomerViewModel>>(userProfiles);

        model.users = userProfileVMs;

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
        string id = "";
        var relationship = (await _relationshipService.Get(id)).FirstOrDefault();

        relationship.Status = 2;
        relationship.DateReplied = DateTime.Now.ToString();
        relationship.CompletedDateTime = DateTime.Now.ToString();

        await _relationshipService.Put(relationship);

        return RedirectToAction("ViewFriendRequests");
    }    
    
    [HttpPost]
    public async Task<IActionResult> DeclineFriendRequest(CustomerViewModel email)
    {
        string id = "";
        var relationship = (await _relationshipService.Get(id)).FirstOrDefault();

        relationship.Status = 3;
        relationship.DateReplied = DateTime.Now.ToString();
        relationship.CompletedDateTime = DateTime.Now.ToString();

        await _relationshipService.Put(relationship);

        return RedirectToAction("ViewFriendRequests");

    }

    [HttpGet]
    public async Task<IActionResult> SendFriendRequest(string id)
    {
        var email = User.Identity.Name;
        var recieverProfile = (await _customerService.Get(id)).FirstOrDefault();
        var senderProfile = (await _customerService.Get(email)).FirstOrDefault();

        var model = new CreateRelationshipDto() {
            SenderId = senderProfile.ModelGuid,
            RecieverId = recieverProfile.ModelGuid,
            CreatedDateTime = DateTime.Now.ToString(),
            CreatorId = email,
            Status = 0,
            ModelGUID = Guid.NewGuid().ToString(),
            DateSent = DateTime.Now.ToString(),
        };

        await _relationshipService.Post(model);


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
