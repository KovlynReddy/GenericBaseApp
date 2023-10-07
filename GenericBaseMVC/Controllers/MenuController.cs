using AutoMapper;
using GenericAppDLL.Models.DomainModel;
using GenericAppDLL.Models.ViewModels;
using GenericBaseMVC.Handlers;
using NuGet.Packaging;
using static Humanizer.In;

namespace GenericBaseMVC.Controllers;

[Route("Menu/[action]")]
public class MenuController : Controller    
{
    public VendorService _VendorService { get; set; }
    public MenuService _MenuService { get; set; }
    public CartService _cartService { get; set; }
    public IMapper Mapper { get; }

    public MenuController(IMapper mapper)
    {
        _MenuService = new MenuService();
        _VendorService = new VendorService();
        _cartService = new CartService();
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ViewCart()
    {
        var model = new CartViewModel();
        var userEmail = User.Identity.Name ?? "none";
        var userService = new CustomerService();
        var Users = await userService.Get(userEmail);
        var user = Users.FirstOrDefault();
        var userId = user.ModelGuid;

        var purchases = await _cartService.Get(userId, "none");
        var items = new List<PurchaseItemDto>();
        var menuItems = new List<MenuItemViewModel>();
        var allItems = await _MenuService.GetAll();

        if (purchases.Count != 0)
        {
            foreach (var purchase in purchases.Where(m=>m.IsPaid == 0))
            {
                var purchaseItems = await _cartService.Get(purchase.CartId);

                foreach (var item in purchaseItems)
                {
                    item.ItemName = allItems.FirstOrDefault(m=>m.ModelGuid==item.ItemGuid).ItemName;
                }

                items.AddRange(purchaseItems);
                model.CartId = purchase.CartId;
            }
        }

        foreach (var item in items)
        {
            var VMs = Mapper.Map<List<MenuItemViewModel>>(allItems.Where(m=>m.ModelGuid == item.ItemGuid).ToList());
            
            menuItems.AddRange(VMs);
        }

        model.purchasedItems = Mapper.Map<List<PurchaseItemViewModel>>(items);
        model.Items = menuItems;

        model.settings = await SettingsHandler.GetSettings(userEmail,true);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> PurchaseTrolleyWithCard(CartViewModel model)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        var dto = new PurchaseCartDto()
        {
            CartId = model.CartId,
            Type = 2,
            OwnerGuid = currentCustomer.ModelGuid
        };

        var results = await _cartService.Put(dto);

        var points = new PointsDto()
        {
            AccountGuid = currentCustomer.AccountGuid,
            Description = "Trolley Purchased",
            Type = 5,
            SenderType = 5,
            UserGuid = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            Amount = 1000,
            CreatedDateTime = DateTime.Now.ToString(),
        };

        await new PointsService().Post(points);
        return RedirectToAction("ViewCart");
    }    
    
    [HttpPost]
    public async Task<IActionResult> PurchaseTrolleyWithPoints(CartViewModel model)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        var dto = new PurchaseCartDto() { 
        CartId = model.CartId,
        Type = 1,
        OwnerGuid = currentCustomer.ModelGuid
        };

        var results = await _cartService.Put(dto);

        return RedirectToAction("ViewCart");
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(MenuItemViewModel model)
    {
        //var model = (await _MenuService.GetAll()).FirstOrDefault(m=>m.ModelGuid == item.ModelGUID);
        var userEmail = User.Identity.Name ?? "none";
        var userService = new CustomerService();
        var Users = await userService.Get(userEmail);
        var user = Users.FirstOrDefault();
        var userId = user.ModelGuid;

        var purchases = await _cartService.Get(userId,"none");
        var unpaid = purchases.FirstOrDefault(m => m.IsPaid == 0);
        var cartId = "";
        if (unpaid!= null && !string.IsNullOrEmpty(unpaid.ModelGuid))
        {
            cartId = unpaid.ModelGuid;
        }
        else 
        {
            cartId = Guid.NewGuid().ToString();
            await _cartService.Post(new CreatePurchaseDto() {
                CartId = cartId,
                Currency = model.Currency,
                CreatedDateTime = DateTime.Now.ToString(),
                IsPaid = 0,
                Amount = model.Amount,
                Cost = model.Cost,
                ModelGuid = cartId,
                Total = model.Cost * model.Amount,
                ItemId = model.ModelGUID,
                CreatorId = userId
            });
        }

        await _cartService.Post(new CreatePurchaseItemDto()
        {
            CartId = cartId,
            CreatedDateTime = DateTime.Now.ToString(),
            IsPaid = 0,
            ItemGuid = model.ModelGUID,
            ModelGuid = Guid.NewGuid().ToString(),
            Amount = model.Amount,
            Cost = model.Cost,
            Currency = model.Currency,
            Total = model.Cost * model.Amount,
            VendorGuid = model.VendorGuid,
            ItemName = model.ItemName,
            DatePurchased = "n/a",
            ItemImage = model.ItemImage == string.Empty || model.ItemImage == null ? "profileimages/defaultimage.jpg" : model.ItemImage
        });
        return RedirectToAction("Dashboard");
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

            foreach (var item in allItems.Where(m => m.VendorId == VendorModel.ModelGUID))
            {
                vendorItems.Add(new MenuItemViewModel()
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


            vendorVMs.Add(new VendorViewModel()
            {
                VendorName = VendorModel.VendorName,
                VendorEmail = VendorModel.VendorEmail,
                ModelGUID = VendorModel.ModelGUID,
                AverageRating = VendorModel.AverageRating,
                CreatedDateTime = VendorModel.CreatedDateTime,
                IsMod = 1,
                AllVendorItems = vendorItems,
                VendorImage = VendorModel.VendorImage == string.Empty || VendorModel.VendorImage == null ? "profileimages/defaultimage.jpg" : VendorModel.VendorImage
            });
        }

        model.AllVendors = vendorVMs.Where(m=>m.AllVendorItems.Count > 0).ToList();
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

        if (!String.IsNullOrEmpty(currentCustomer.AccountGuid))
        {
            var transactions = Mapper.Map<List<PointsViewModel>>(await new PointsService().Get(currentCustomer.ModelGuid));

            model.TotalPoints = transactions.Sum(m => m.Amount);
        }

        return View("ShopDashboard",model);
    }

    [HttpGet]
    public async Task<IActionResult> ViewAll() 
    {
        var model = new ViewListMenuItems();
        var respomse = await _MenuService.GetAll();

        model.items = Mapper.Map<List<MenuItemViewModel>>(respomse.ToList());

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);
        return View(model);
    }    
    
    [HttpGet]
    public async Task<IActionResult> ShopDashboard()
    {
        var ventors = await _VendorService.GetAll();
        var menuItems = await _MenuService.GetAll();

        ShopDashboardViewModel model = new ShopDashboardViewModel();


        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);
        return View(model);
    }    
    
    [HttpGet]
    public async Task<IActionResult> ViewShopDashboard(string id)
    {
        var ventors = await _VendorService.GetAll();
        var menuItems = await _MenuService.GetAll();

        ShopDashboardViewModel model = new ShopDashboardViewModel();


        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);
        return View(model);
    }

    [HttpGet]
    public async Task<ActionResult> Edit(string id)
    {
        var alItems = await _MenuService.GetAll();
        var model = new MenuItemViewModel();

        var itemDetails = alItems.FirstOrDefault(m=>m.ModelGuid==id);
        model = Mapper.Map<MenuItemViewModel>(itemDetails);

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

        return View("EditMenuItem",model);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(MenuItemViewModel updatedMenuItem)
    {
        var updatedItem = Mapper.Map<MenuItemDto>(updatedMenuItem);
        await _MenuService.EditMenu();
        return RedirectToAction("Dashboard");
    }


    [HttpGet]
    public async Task<ActionResult> Delete(string id)
    {

        return View();
    }

    // GET: MenuController/Details/5
    public async Task<ActionResult> Details(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return RedirectToAction(actionName: "ShopDashboard");
        }

        var menuItems = await _MenuService.GetAll();

        var item = menuItems.FirstOrDefault(m=>m.ModelGuid==id);
        var model = new MenuItemViewModel()
        {
            ItemName = item.ItemName,
            SKUCode = item.SKUCode,
            Caption = item.Caption,
            Cost = item.Cost,
            Currency = item.Currency,
            ItemImage = item.Path == string.Empty || item.Path == null ? "profileimages/defaultimage.jpg" : item.Path,
            MenuId = item.MenuId,
            ModelGUID = item.ModelGuid,
            IsMod = 1,
            VendorGuid = item.VendorId
        };

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

        return View(model);
    }

    // GET: MenuController/Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        CreateMenuItemViewModel model = new CreateMenuItemViewModel();

        model.Caption = "FlatTop";
        model.Cost = 100;
        model.Currency = "R";
        model.ItemName = "TestCut1";
        model.SKUCode = "TC012709";
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> ManageVendorMenu(string id)
    {
        var model = new ManageVendorMenuViewModel();

        var allVendors = await _VendorService.GetAll();
        var allItems = await _MenuService.GetAll();

        var VendorModel = allVendors.FirstOrDefault(m => m.ModelGUID == id);
        
            var vendorItems = new List<MenuItemViewModel>();

            foreach (var item in allItems.Where(m => m.VendorId == id))
            {
                vendorItems.Add(new MenuItemViewModel()
                {
                    ItemName = item.ItemName,
                    SKUCode = item.SKUCode,
                    Caption = item.Caption,
                    Cost = item.Cost,
                    AverageRating = item.AverageRating,
                    AverageRatingInt = Convert.ToInt16(item.AverageRating),
                    Currency = item.Currency,
                    ItemImage = item.Path == string.Empty || item.Path == null ? "profileimages/defaultimage.jpg" : item.Path,
                    MenuId = item.MenuId,
                    VendorGuid = item.VendorId,
                    ModelGUID = item.ModelGuid,
                    IsMod = 1
                });
            }

            model.menu = vendorItems;

            model.VendorDetails = new VendorViewModel()
            {
                VendorName = VendorModel.VendorName,
                VendorEmail = VendorModel.VendorEmail,
                ModelGUID = VendorModel.ModelGUID,
                AverageRating = VendorModel.AverageRating,
                CreatedDateTime = VendorModel.CreatedDateTime,
                IsMod = 1,
                AllVendorItems = vendorItems,
                VendorImage = VendorModel.VendorImage == string.Empty || VendorModel.VendorImage == null ? "profileimages/profileimage.png" : VendorModel.VendorImage
            };      
                
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

        return View("ManageVendorMenu", model);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuItemViewModel newMenuItem)
    {
        try
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(newMenuItem.ItemImage.FileName);
            string fileName = newMenuItem.ItemImage.FileName + Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                newMenuItem.ItemImage.CopyTo(stream);
            }

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
                VendorId = newMenuItem.VendorId,
                MenuItemMainImage = fileName,

            };

            await _MenuService.Post(model);


            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

}

