﻿using AutoMapper;
using GenericBaseMVC.Handlers;

namespace GenericBaseMVC.Controllers;

public class ProfileController : Controller
{

    public VendorService _VendorService { get; set; }
    public CustomerService _customerService { get; set; }
    public AddressService _addressService { get; set; }
    public BookingService _bookingService { get; set; }
    public PostService _postService { get; set; }
    public JournalService _journalService { get; set; }
    public MeetUpService _meetUpService { get; set; }
    public RelationshipService _relationshipService { get; set; }
    public ProfileHandler _profileHandler { get; set; }
    public IMapper Mapper { get; }


    public ProfileController(IMapper mapper)
    {
        _postService = new PostService();
        _meetUpService = new MeetUpService();
        _journalService = new JournalService();
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
        var currentCustomerId = customerDetails.ModelGuid;

        var relationships = (await _relationshipService.Get(currentCustomerId)).Where(m=>m.Status == 2 ).ToList();

        foreach (var relationship in relationships)
        {
            string otherid = "";
            if (currentCustomerId == relationship.SenderId)
            {
                otherid = relationship.RecieverId;
            }
            else {
                otherid = relationship.SenderId;
            }

            model.Friends.Add(Mapper.Map<CustomerViewModel>((await _customerService.Get(otherid)).FirstOrDefault()));
           
        }

        if (!String.IsNullOrEmpty(customerDetails.AccountGuid))
        {
            var transactions = Mapper.Map<List<PointsViewModel>>(await new PointsService().Get(currentCustomerId));
            model.Transactions = transactions;

            model.TotalPoints = transactions.Sum(m=>m.Amount);
        }

        model.profileDetails = Mapper.Map<CustomerViewModel>(customerDetails);
        model.settings = await SettingsHandler.GetSettings(email);
        //model.Friends = _customerService.Get();
        model.Journals = Mapper.Map<List<JournalViewModel>>((await _journalService.Get(currentCustomerId)));
        foreach (var journal in model.Journals)
        {
            var csv = journal.uploadPaths;
            var files = csv.Split(',').ToList();
            files.Remove("");
            journal.uploadPathsList = files;

        }

        var allItems =await (new MenuService().GetAll());
        var allItemVM = new List<MenuItemViewModel>();

        foreach (var item in allItems)
        {
            allItemVM.Add(new MenuItemViewModel()
            {
                ItemName = item.ItemName,
                SKUCode = item.SKUCode,
                AverageRating = item.AverageRating,
                AverageRatingInt = Convert.ToInt16(item.AverageRating),
                Caption = item.Caption,
                Cost = item.Cost,
                Currency = item.Currency,
                ItemImage = item.Path == string.Empty || item.Path == null ? "profileimages/defaultimage.jpg" : item.Path,
                MenuId = item.MenuId,
                ModelGUID = item.ModelGuid,
                IsMod = 1,
                VendorGuid = item.VendorId
            });
        }


        var myItems = model.Journals.Select(m=>m.ItemGuid).Distinct().ToList();

        foreach (var item in myItems)
        {
            var itemDetails = allItemVM.FirstOrDefault(m => m.ModelGUID == item);
            if (itemDetails == null)
            {
                continue;
            }

            model.Items.Add(itemDetails);
        }


        //model.Journals = Mapper.Map<List<JournalViewModel>>(await _journalService.Get(currentCustomerId));
        model.Posts = Mapper.Map<List<PostViewModel>>(await _postService.Get(currentCustomerId));
        model.Meetups = Mapper.Map<List<MeetupViewModel>>(await _meetUpService.Get(currentCustomerId));


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
        model.settings = await SettingsHandler.GetSettings(email);
        return View("ViewProfile",model); 
       
    }       
    
    [HttpGet]
    public async Task<IActionResult> ViewFriendRequests()
    {
        var email = User.Identity.Name;
        var model = await _profileHandler.ViewFriendRequests(email);
        model.settings = await SettingsHandler.GetSettings(email, true);
        return View(model); 
       
    }    
    
    [HttpPost]
    public async Task<IActionResult> ViewProfile(CustomerViewModel email)
    {
        var model = await GetCustomerProfile(email.ModelGUID); 

        return View("ViewProfile",model); 
       
    }

    [HttpGet]
    public async Task<IActionResult> ViewProfileById(string email)
    {
        var model = await GetCustomerProfile(email);

        return View("ViewProfile", model);

    }

    [HttpGet]
    public async Task<IActionResult> AcceptFriendRequest(string id)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

        var relationship = await _profileHandler.RespondToFriendRequest(id, 2);

        var points = new PointsDto()
        {
            AccountGuid = currentCustomer.AccountGuid,
            Description = "Added Friend",
            Type = 1,
            SenderType = 1,
            UserGuid = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            Amount = 5,
            CreatedDateTime = DateTime.Now.ToString(),
        };

        await new PointsService().Post(points);

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
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

        var model = await _profileHandler.SendFriendRequest(id,email);

        var points = new PointsDto()
        {
            AccountGuid = currentCustomer.AccountGuid,
            Description = "Friend Request Sent",
            Type = 1,
            SenderType = 1,
            UserGuid = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            Amount = 10,
            CreatedDateTime = DateTime.Now.ToString(),
        };

        await new PointsService().Post(points);

        return View("ViewProfile");

    }

    public async Task<IActionResult> Index()
    {
        var email = User.Identity.Name;
        var model = await _profileHandler.GetAllProfiles(email);
        model.settings = await SettingsHandler.GetSettings(email, true);
        return View(model);
    }
}
 