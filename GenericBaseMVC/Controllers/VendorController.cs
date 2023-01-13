namespace GenericBaseMVC.Controllers;

public class VendorController : Controller
{
    public VendorService _barberService { get; set; }
    public AddressService _addressService { get; set; }

    public VendorController()
    {
        _barberService = new VendorService();
        _addressService = new AddressService();
    }


    // GET: BarberController
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var allBarbers = await _barberService.GetAll(); 

        return View("ViewListBarbers",allBarbers);
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll()
    {
        var allBarbers = await _barberService.GetAll();

        return View("ViewListBarbers", allBarbers);
    }

    // GET: BarberController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: BarberController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BarberController/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateVendorViewModel newbarbervm)
    {
        try

        {
            CreateVendorDto newbarber = new CreateVendorDto
            {
                VendorEmail = newbarbervm.VendorEmail,
                VendorName = newbarbervm.VendorName
            };
          
            var result = await _barberService.Create(newbarber);
            return View("ViewBarber",newbarbervm);
        }
        catch
        {

            return View();
        }
    }

    // GET: BarberController/Edit/5
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
        // get all barbers
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



        var allBarbers = await _barberService.GetAll();
        var allAddresses = await _addressService.GetAll();
        var allBarberAddresses = new List<AddressDto>();
        var suggestedBarbers = new List<AddressDto>();

        // get all barbers addresses

        foreach (var Barber in allBarbers)
        {
            allBarberAddresses.Add(allAddresses.FirstOrDefault(m=>m.UserGuid == Barber.ModelGUID));
            //allBarberAddresses.Add(allAddresses.FirstOrDefault(m => m.UserGuid == Barber.ModelGUID));
        }

        MapViewModel model = new MapViewModel();

        // according to my location + - give as suggested
        foreach (var bAddress in allBarberAddresses)
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
                suggestedBarbers.Add(bAddress);
            }
        }

        // display on a map centered at location
        model.CenterLat = (-29.766807).ToString();
        model.CenterLon = (30.984297).ToString();
        model.Scale = 100.ToString();
        model.Zoom = 16.ToString();


        return View("_MapView", model);
       // return RedirectToAction("DisplaySuggested",model);
    }

    [HttpGet]
    public async Task<IActionResult> DisplaySuggestedLocations(MapViewModel model)
    {
        return View("_MapView",model);
    }


    // POST: BarberController/Edit/5
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
    public async Task<IActionResult> DisplaySuggested(string slat, string slon)
    {
        // get all barbers
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



        var allBarbers = await _barberService.GetAll();
        var allAddresses = await _addressService.GetAll();
        var allBarberAddresses = new List<AddressDto>();
        var suggestedBarbers = new List<AddressDto>();

        // get all barbers addresses

        foreach (var Barber in allBarbers)
        {
            var barberAddress = allAddresses.FirstOrDefault(m => m.UserGuid == Barber.ModelGUID);
            if (barberAddress == null)
            {
                continue;
            }
            barberAddress.Caption = Barber.VendorName;
            allBarberAddresses.Add(barberAddress);
            //allBarberAddresses.Add(allAddresses.FirstOrDefault(m => m.UserGuid == Barber.ModelGUID));
        }

        MapViewModel model = new MapViewModel();

        // according to my location + - give as suggested
        foreach (var bAddress in allBarberAddresses)
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
                suggestedBarbers.Add(bAddress);
            }
        }

        // display on a map centered at location
        model.CenterLat = slat.Replace(',', '.');
        model.CenterLon = slon.Replace(',', '.');
        model.Scale = 100.ToString();
        model.Zoom = 16.ToString();


        return View("_MapView", model);
        // return RedirectToAction("DisplaySuggested",model);
    }


    // GET: BarberController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BarberController/Delete/5
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
