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

    // GET: Deals
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Deals.ToListAsync());
    }

    // GET: Deals/Details/5
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

    // GET: Deals/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Deals/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BarberGuid,Description,StartDate,EndDate,Reason,Percentage,Amount,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Deal deal)
    {
        if (ModelState.IsValid)
        {
            _context.Add(deal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(deal);
    }

    // GET: Deals/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deal = await _context.Deals.FindAsync(id);
        if (deal == null)
        {
            return NotFound();
        }
        return View(deal);
    }

    // POST: Deals/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BarberGuid,Description,StartDate,EndDate,Reason,Percentage,Amount,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Deal deal)
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

    // GET: Deals/Delete/5
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

    // POST: Deals/Delete/5
    [HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deal = await _context.Deals.FindAsync(id);
        _context.Deals.Remove(deal);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DealExists(int id)
    {
        return _context.Deals.Any(e => e.Id == id);
    }
}
