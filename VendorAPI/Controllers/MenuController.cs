namespace VendorAPI.Controllers;

[Route("api/Menu/[action]")]
[ApiController]
public class MenuController : Controller
{
    private readonly VendorContext _context;

    public MenuController(VendorContext context)
    {
        _context = context;
    }

    // GET: Menu
    public async Task<IActionResult> Index()
    {
        return View(await _context.Items.ToListAsync());
    }


    [Route("~/api/Menu/GetAll")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var AllItems = await _context.Items.ToListAsync();
        List<MenuItemDto> response = new List<MenuItemDto>();

        foreach (var item in AllItems)
        {
            var itemDto = new MenuItemDto
            {
                ItemName = item.ItemName,
                //ItemImage = .ItemImage,
                UserGuid = User.Identity.Name,
                SKUCode = item.SKUCode,
                ModelGuid = item.ModelGUID,
                CreatedDateTime = DateTime.Parse(item.CreatedDateTime),
                CreatorId = User.Identity.Name,
                VendorGuid =item.VendorId,
                VendorId =item.VendorId,
                Caption = item.Caption,
                Cost = item.Cost,
                MenuId = item.MenuId,
                Currency = item.Currency,
                CreatedDateTimeString = item.CreatedDateTime,
                ItemImage = item.Path == string.Empty || item.Path == null ? "profileimages/defaultimage.jpg" : item.Path

            };

            response.Add(itemDto);

        }
               

        return Ok(response);
    }

    // GET: Menu/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _context.Items
            .FirstOrDefaultAsync(m => m.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("~/api/Menu")]
   public async Task<IActionResult> Post([FromBody]CreateMenuItemDto item)
    {
        if (ModelState.IsValid)
        {
            Item newItem = new Item
            {
                ItemName = item.ItemName,
                //ItemImage = newMenuItem.ItemImage,
                //UserGuid = User.Identity.Name,
                SKUCode = item.SKUCode,
                ModelGUID = Guid.NewGuid().ToString(),
                CreatedDateTime = DateTime.Now.ToString(),
                CreatorId = User.Identity.Name ?? "",
                VendorId = item.VendorId,
                Caption = item.Caption,
                Cost = item.Cost,
                MenuId = item.MenuId,
                Currency = item.Currency,
                Path = item.MenuItemMainImage
                //CreatedDateTimeString = DateTime.Now.ToString(),

            };

            _context.Add(newItem);
            await _context.SaveChangesAsync();
            return Ok(newItem);
        }
        return Ok(item);
    }

    // GET: Menu/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    // GET: Menu/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _context.Items
            .FirstOrDefaultAsync(m => m.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // POST: Menu/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Items.FindAsync(id);
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ItemExists(int id)
    {
        return _context.Items.Any(e => e.Id == id);
    }
}
