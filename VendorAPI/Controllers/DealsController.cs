namespace VendorAPI.Controllers;

[Route("api/[Controller]/[Action]")]
[ApiController]
public class DealsController : Controller
{

    private readonly VendorContext _context;

    public DealsController(VendorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Deals.ToListAsync());
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deal = await _context.Deals
            .FirstOrDefaultAsync(m => m.Id == id);
        if (deal == null)
        {
            return NotFound();
        }

        return View(deal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("VendorGuid,Description,StartDate,EndDate,Reason,Percentage,Amount,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Deal deal)
    {
        if (ModelState.IsValid)
        {
            _context.Add(deal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(deal);
    }

    [HttpPatch]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VendorGuid,Description,StartDate,EndDate,Reason,Percentage,Amount,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Deal deal)
    {
        if (id != deal.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(deal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealExists(deal.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(deal);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deal = await _context.Deals
            .FirstOrDefaultAsync(m => m.Id == id);
        if (deal == null)
        {
            return NotFound();
        }

        return View(deal);
    }

    private bool DealExists(int id)
    {
        return _context.Deals.Any(e => e.Id == id);
    }
}
