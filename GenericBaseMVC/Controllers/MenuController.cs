namespace GenericBaseMVC.Controllers;

[Route("Menu/[action]")]
public class MenuController : Controller
{
    public VendorService _VendorService { get; set; }
    public MenuService _MenuService { get; set; }

    public MenuController()
    {
        _MenuService = new MenuService();
        _VendorService = new VendorService();
    }

    [HttpGet]
    public async Task<IActionResult> ViewCart()
    {
        return View();
    }    
    
    [HttpPost]
    public async Task<IActionResult> AddToCart(string Id)
    {
        return View();
    }

   [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        ShopDashboardViewModel model = new ShopDashboardViewModel();
        var allVendors = await _VendorService.GetAll();
        var allItems = await _MenuService.GetAll();
        var vendorVMs = new List<VendorViewModel>();
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
                    ItemImage = item.ItemImage,
                    MenuId = item.MenuId,
                    IsMod = 1
                });
            }


            vendorVMs.Add(new VendorViewModel()
            {
                VendorName = VendorModel.VendorName,
                VendorEmail = VendorModel.VendorEmail,
                ModelGUID = VendorModel.ModelGUID,
                AverageRating = VendorModel.AverageRating,
                CreatedDateTime = VendorModel.CreatedDateTime,
                IsMod = 1,
                AllVendorItems = vendorItems
            });
        }

        model.AllVendors = vendorVMs.Where(m=>m.AllVendorItems.Count > 0).ToList();
        return View("ShopDashboard",model);
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll()
    {
        var respomse = await _MenuService.GetAll();

        return View(respomse);
    }    
    
    [HttpGet]
    public async Task<IActionResult> ShopDashboard()
    {
        var ventors = await _VendorService.GetAll();
        var menuItems = await _MenuService.GetAll();

        ShopDashboardViewModel model = new ShopDashboardViewModel();

        return View(model);
    }    
    
    [HttpGet]
    public async Task<IActionResult> ViewShopDashboard(string id)
    {
        var ventors = await _VendorService.GetAll();
        var menuItems = await _MenuService.GetAll();

        ShopDashboardViewModel model = new ShopDashboardViewModel();

        return View(model);
    }


    // GET: MenuController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: MenuController/Create
    [HttpGet]
    public IActionResult Create()
    {
        CreateMenuItemViewModel model = new CreateMenuItemViewModel();

        model.Caption = "FlatTop";
        model.Cost = 100;
        model.Currency = "R";
        model.ItemName = "TestCut1";
        model.SKUCode = "TC012709";

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> ManageVendorMenu(string id)
    {
        var allVendors = await _VendorService.GetAll();
        var allItems = await _MenuService.GetAll();
        var model = new List<VendorViewModel>();
        foreach (var VendorModel in allVendors.Where(m=>m.ModelGUID==id))
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
                    ItemImage = item.ItemImage,
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
                AllVendorItems = vendorItems
            });
        }

        var addModel = model.FirstOrDefault();
        CreateMenuItemViewModel addVM = new CreateMenuItemViewModel() { 
        VendorId = id
        };

        return View("Create",addVM);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuItemViewModel newMenuItem)
    {
        try
        {
            CreateMenuItemDto model = new CreateMenuItemDto()
            {
                ItemName = newMenuItem.ItemName,
                //ItemImage       = newMenuItem.ItemImage,
                UserGuid = User.Identity.Name ?? "",
                SKUCode = newMenuItem.SKUCode,
                ModelGuid = new Guid().ToString(),
                CreatedDateTime = DateTime.Now,
                CreatorId = User.Identity.Name?? string.Empty,
                VendorGuid = User.Identity.Name ?? "",
                Caption = newMenuItem.Caption,
                Cost = newMenuItem.Cost,
                MenuId = newMenuItem.MenuId,
                Currency = newMenuItem.Currency,
                CreatedDateTimeString = DateTime.Now.ToString(),
                VendorId = newMenuItem.VendorId
            };

            await _MenuService.Create(model);


            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

}
