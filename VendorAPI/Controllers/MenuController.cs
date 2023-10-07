using AutoMapper;

namespace VendorAPI.Controllers;

[Route("api/Menu/[action]")]
[ApiController]
public class MenuController : Controller
{
    private readonly VendorContext _context;
    private readonly IMapper _mapper;

    public MenuController(VendorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
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
            var itemDto = _mapper.Map<MenuItemDto>(item);

            itemDto.Path = item.Path == string.Empty || item.Path == null ? "profileimages/defaultimage.jpg" : item.Path;           

            response.Add(itemDto);
        }
        response.Reverse();

        return Ok(response);
    }

    [HttpGet]
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

    [HttpDelete]
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

    private bool ItemExists(int id)
    {
        return _context.Items.Any(e => e.Id == id);
    }
}
