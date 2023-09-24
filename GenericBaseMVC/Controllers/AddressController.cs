using GenericBaseMVC.Handlers;

namespace GenericBaseMVC.Controllers;


public class AddressController : Controller
{
    public VendorService _VendorService { get; set; }
    public CustomerService _customerService { get; set; }
    public AddressService _addressService { get; set; }
    public AddressController()
    {
        _addressService = new AddressService();
        _customerService = new CustomerService();
        _VendorService = new VendorService();
    }
        
    // GET: AddressController
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LinkAddress()
    {
        LinkAddressViewModel model = new LinkAddressViewModel();

        var AllAddresses = await _addressService.GetAll();
        var AllVendors = await _VendorService.GetAll();
        var AllCustomers = await _customerService.Get();

        // Ignore Code

        foreach (var item in AllAddresses)
        {
            item.Caption = Guid.NewGuid().ToString();
        }

        // avoiding Caption = null

        model.Addresses = AllAddresses.Select(a =>
                              new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                              {
                                  Value = a.ModelGuid,
                                  Text = a.ModelGuid
                              }).ToList();

        model.People = AllCustomers.Select(a =>
                              new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                              {
                                  Value = a.ModelGuid ,
                                  Text = a.CustomerEmail.ToString()
                              }).ToList();

        model.People.AddRange(AllVendors.Select(a =>
                              new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                              {
                                  Value = a.ModelGUID ,
                                  Text = a.VendorEmail.ToString()
                              }).ToList());

        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> LinkAddress(LinkAddressViewModel model)
    {
        LinkAddressDto link = new LinkAddressDto();
        link.AddressGuid = model.AddressGuid;
        link.UserGuid = model.UserGuid; 

        await _addressService.LinkAddress(link);

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ViewMap()
    {
        MapViewModel model = new MapViewModel { 
        Lats = new List<string> {
        "-29.866807",
        "-29.966807",
        "-29.996807"
        },
        Longs = new List<string> {
        "30.884297",
        "30.784297",
        "30.684297"
        },
        Captions = new List<string> {
        "1",
        "2",
        "3"
        }, 
        Names = new List<string> {
        "a",
        "b",
        "c"
        },
        CenterLat = (-29.766807).ToString(), 
        CenterLon = (30.984297).ToString(), 
        Scale = 100.ToString() , 
        Zoom = 16.ToString()

        };


        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);
        return View("_MapView",model);
    }

    // GET: AddressController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: AddressController/Create
    public ActionResult Create()
    {
        CreateAddressViewModel model = new CreateAddressViewModel();

        return View(model);
    }

    // POST: AddressController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAddressViewModel newAddress)
    {
        try
        {
            CreateAddressDto newAddressDto = new CreateAddressDto {
                Number = newAddress.Number,
                Street = newAddress.Street,
                MainStreet = newAddress.MainStreet,
                Suburb = newAddress.Suburb,
                Country = newAddress.Country,
                PostCode = newAddress.PostCode,
                ModelGuid = newAddress.ModelGuid,
                CreatedDateTime = DateTime.Now,
                CreatorGuid = User.Identity.Name,
                Lat = newAddress.Lat,
                lon = newAddress.lon,
            };

            var response = await _addressService.Create(newAddressDto);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: AddressController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll() {

        var response = await _addressService.GetAll();

        var AddressViewModel = ConvertToViewModel(response);


        return View(AddressViewModel);
    }

    // POST: AddressController/Edit/5
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

    // GET: AddressController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: AddressController/Delete/5
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

    private List<AddressViewModel> ConvertToViewModel(List<AddressDto> argument)
    {

        var response = new List<AddressViewModel>();

        foreach (var item in argument)
        {

            AddressViewModel Address = new AddressViewModel
            {
                Number = item.Number,
                Street = item.Street,
                MainStreet = item.MainStreet,
                Suburb = item.Suburb,
                Country = item.Country,
                PostCode = item.PostCode,
                ModelGuid = item.ModelGuid,
                Lat = item.Lat,
                lon = item.lon
            };

            response.Add(Address);
        }
        return response;
    }
}
