using GenericAppDLL.Models.DomainModel;
using GenericAppDLL.Models.ViewModels;
using GenericBaseMVC.Handlers;
using System.Net;

namespace GenericBaseMVC.Controllers;

public class VendorController : Controller
{
    public VendorService _VendorService { get; set; }
    public AddressService _addressService { get; set; }
    public MenuService _itemService { get; set; }

    public VendorController()
    {
        _VendorService = new VendorService();
        _addressService = new AddressService();
        _itemService = new MenuService();
    }


    // GET: VendorController
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var allVendors = await _VendorService.GetAll();
        var allItems = await _itemService.GetAll();
        var model = new List<VendorViewModel>();
        var vm = new ViewListVendorViewModel();

        foreach (var VendorModel in allVendors)
        {
            var vendorItems = new List<MenuItemViewModel>();

            foreach (var item in allItems.Where(m=>m.VendorGuid==VendorModel.ModelGUID))
            {
                vendorItems.Add(new MenuItemViewModel() { 
                ItemName    = item.ItemName,
                SKUCode     = item.SKUCode,
                Caption     = item.Caption,
                Cost        = item.Cost,
                CreatorId   = item.CreatorId,
                Currency    = item.Currency,
                ItemImage   = item.ItemImage,
                MenuId      = item.MenuId,
                IsMod       = 1
                });
            }


            model.Add(new VendorViewModel() { 
            VendorName      = VendorModel.VendorName,
            VendorEmail     = VendorModel.VendorEmail,
            ModelGUID       = VendorModel.ModelGUID,
            AverageRating   = VendorModel.AverageRating,
            CreatedDateTime = VendorModel.CreatedDateTime,
            IsMod           = 1,
            AllVendorItems  = vendorItems,
                VendorImage = VendorModel.VendorImage
            });
        }

        vm.vendors = model;
        var email = User.Identity.Name;
        vm.settings = await SettingsHandler.GetSettings(email);
        return View("ViewListVendors", vm);
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll()
    {
        var allVendors = await _VendorService.GetAll();
        var allItems = await _itemService.GetAll();
        var model = new List<VendorViewModel>();
        var vm = new ViewListVendorViewModel();

        foreach (var VendorModel in allVendors)
        {
            var vendorItems = new List<MenuItemViewModel>();

            foreach (var item in allItems.Where(m => m.VendorGuid == VendorModel.ModelGUID))
            {
                vendorItems.Add(new MenuItemViewModel()
                {
                    ItemName = item.ItemName,
                    SKUCode = item.SKUCode,
                    Caption = item.Caption,
                    Cost = item.Cost,
                    CreatorId = item.CreatorId,
                    Currency = item.Currency,
                    ItemImage = item.ItemImage == string.Empty || item.ItemImage == null ? "profileimages/defaultimage.jpg" : item.ItemImage,
                    MenuId = item.MenuId,
                    IsMod = 1
                });
            }


            model.Add(new VendorViewModel()
            {
                VendorName = VendorModel.VendorName,
                VendorEmail = VendorModel.VendorEmail,
                ModelGUID = VendorModel.ModelGUID,
                AverageRating = VendorModel.AverageRating,
                CreatedDateTime = VendorModel.CreatedDateTime,
                IsMod = 1,
                AllVendorItems = vendorItems,
                VendorImage = VendorModel.VendorImage == string.Empty || VendorModel.VendorImage == null ? "profileimages/profileimage.png" : VendorModel.VendorImage
            });
        }
        vm.vendors = model;

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        vm.settings = await SettingsHandler.GetSettings(email);


        return View("ViewListVendors", vm);
    }

    // GET: VendorController/Details/5
    public async Task<IActionResult> ManageVendorMenu(int id)
    {
        return View();
    }    
    
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: VendorController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: VendorController/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateVendorViewModel newVendorvm)
    {
        try
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(newVendorvm.VendorImage.FileName);
            string fileName = newVendorvm.VendorImage.FileName + Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                newVendorvm.VendorImage.CopyTo(stream);
            }


            CreateVendorDto newVendor = new CreateVendorDto
            {
                VendorEmail = newVendorvm.VendorEmail,
                VendorName = newVendorvm.VendorName,
                VendorImage = fileName
            };
          
            var result = await _VendorService.Create(newVendor);
            return View("ViewVendor",newVendorvm);
        }
        catch
        {

            return View();
        }
    }

    // GET: VendorController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Suggested()
    {
       return View();
    }

   [HttpPost]
    public async Task<IActionResult> Suggested(string slat , string slon) {
        // get all Vendors
        double lon;
        float lat;
        try
        {
            slon = slon.Replace('.',',');
            slat = slat.Replace('.', ',');
            double example = Convert.ToDouble("23,4434");
            lon = Convert.ToDouble(slon);
            lat = float.Parse(slat);

        }
        catch (Exception e)
        {
            var  message = e.Message;
            throw;
        }



        var allVendors = await _VendorService.GetAll();
        var allAddresses = await _addressService.GetAll();
        var allVendorAddresses = new List<AddressDto>();
        var suggestedVendors = new List<AddressDto>();

        // get all Vendors addresses

        foreach (var Vendor in allVendors)
        {
            allVendorAddresses.Add(allAddresses.FirstOrDefault(m=>m.UserGuid == Vendor.ModelGUID));
            //allVendorAddresses.Add(allAddresses.FirstOrDefault(m => m.UserGuid == Vendor.ModelGUID));
        }

        MapViewModel model = new MapViewModel();

        // according to my location + - give as suggested
        foreach (var bAddress in allVendorAddresses)
        {
            if (bAddress == null || bAddress.Lat == null || string.IsNullOrEmpty(bAddress.Lat))
            {
                continue;
            }
            var latdistance = float.Parse(bAddress.Lat.Replace('.', ',')) - lat;
            var londistance = double.Parse(bAddress.lon.Replace('.', ',')) - lon;
            if (  Math.Abs(latdistance) < 10 || Math.Abs(londistance) < 10)
            {
                model.Lats.Add(bAddress.Lat.ToString());
                model.Longs.Add(bAddress.lon.ToString());
                model.Captions.Add(bAddress.Caption);
                model.Names.Add(bAddress.Number + bAddress.Street);
                suggestedVendors.Add(bAddress);
            }
        }

        // display on a map centered at location
        model.CenterLat = (-29.766807).ToString();
        model.CenterLon = (30.984297).ToString();
        model.Scale = 100.ToString();
        model.Zoom = 16.ToString();
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);


        return View("_SuggestedMapView", model);
       // return RedirectToAction("DisplaySuggested",model);
    }

    [HttpGet]
    public async Task<IActionResult> DisplaySuggestedLocations(MapViewModel model)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

        return View("_SuggestedMapView",model);
    }


    // POST: VendorController/Edit/5
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

    [HttpGet]
    public async Task<IActionResult> DisplaySuggested(decimal slat, decimal slon)
    {

        return null;
    }

        [HttpGet]
    public async Task<IActionResult> DisplaySuggested(string slat, string slon)
    {
        // get all Vendors
        double lon;
        float lat;
        try
        {
            slon = slon.Replace('.', ',');
            slat = slat.Replace('.', ',');
            double example = Convert.ToDouble("23,4434");
            lon = Convert.ToDouble(slon);
            lat = float.Parse(slat);

        }
        catch (Exception e)
        {
            var message = e.Message;
            throw;
        }



        var allVendors = await _VendorService.GetAll();
        var allAddresses = await _addressService.GetAll();
        var allVendorAddresses = new List<AddressDto>();
        var suggestedVendors = new List<AddressDto>();

        // get all Vendors addresses

        foreach (var Vendor in allVendors)
        {
            var VendorAddress = allAddresses.FirstOrDefault(m => m.UserGuid == Vendor.ModelGUID);
            if (VendorAddress == null)
            {
                continue;
            }
            VendorAddress.Caption = Vendor.VendorName;
            allVendorAddresses.Add(VendorAddress);
            //allVendorAddresses.Add(allAddresses.FirstOrDefault(m => m.UserGuid == Vendor.ModelGUID));
        }

        MapViewModel model = new MapViewModel();

        // according to my location + - give as suggested
        foreach (var bAddress in allVendorAddresses)
        {
            if (bAddress == null || bAddress.Lat == null || string.IsNullOrEmpty(bAddress.Lat))
            {
                continue;
            }
            var latdistance = float.Parse(bAddress.Lat.Replace('.', ',')) - lat;
            var londistance = double.Parse(bAddress.lon.Replace('.', ',')) - lon;
            if (Math.Abs(latdistance) < 10 || Math.Abs(londistance) < 10)
            {
                model.Lats.Add(bAddress.Lat.ToString());
                model.Longs.Add(bAddress.lon.ToString());
                model.Captions.Add(bAddress.Caption);
                model.Names.Add(bAddress.Caption+" - "+bAddress.Number+" " + bAddress.Street);
                suggestedVendors.Add(bAddress);
            }
        }

        // display on a map centered at location
        model.CenterLat = slat.Replace(',', '.');
        model.CenterLon = slon.Replace(',', '.');
        model.Scale = 100.ToString();
        model.Zoom = 16.ToString();
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);


        return View("_SuggestedMapView", model);
        // return RedirectToAction("DisplaySuggested",model);
    }


    // GET: VendorController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: VendorController/Delete/5
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
