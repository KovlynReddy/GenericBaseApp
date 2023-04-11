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


    public ActionResult Index()
    {
        return View();
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


    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuItemViewModel newMenuItem)
    {
        try
        {
            CreateMenuItemDto model = new CreateMenuItemDto()
            {
                ItemName = newMenuItem.ItemName,
                //ItemImage       = newMenuItem.ItemImage,
                UserGuid = User.Identity.Name,
                SKUCode = newMenuItem.SKUCode,
                ModelGuid = new Guid().ToString(),
                CreatedDateTime = DateTime.Now,
                CreatorId = User.Identity.Name,
                BarberGuid = User.Identity.Name,
                Caption = newMenuItem.Caption,
                Cost = newMenuItem.Cost,
                MenuId = newMenuItem.MenuId,
                Currency = newMenuItem.Currency,
                CreatedDateTimeString = DateTime.Now.ToString(),
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
