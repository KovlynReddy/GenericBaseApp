namespace VendorAPI.Controllers;

[Route("api/Visits")]
[ApiController]
public class LogVisitsController : Controller
{
    private readonly VendorContext _context;

    public LogVisitsController(VendorContext context)
    {
        _context = context;
    }

    // GET: LogVisits
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.LogVisits.ToListAsync());
    }

    // GET: LogVisits/Details/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var logVisit = await _context.LogVisits
            .FirstOrDefaultAsync(m => m.Id == id);
        if (logVisit == null)
        {
            return NotFound();
        }

        return View(logVisit);
    }


    // POST: LogVisits/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("VendorGuid,UserGuid,Reason,Rating,Description,BookingTime,ArriveTime,CompletionTime,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] LogVisit logVisit)
    {
        if (ModelState.IsValid)
        {
            _context.Add(logVisit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(logVisit);
    }

    // POST: LogVisits/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPatch("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VendorGuid,UserGuid,Reason,Rating,Description,BookingTime,ArriveTime,CompletionTime,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] LogVisit logVisit)
    {
        if (id != logVisit.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(logVisit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogVisitExists(logVisit.Id))
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
        return View(logVisit);
    }

    // GET: LogVisits/Delete/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var logVisit = await _context.LogVisits
            .FirstOrDefaultAsync(m => m.Id == id);
        if (logVisit == null)
        {
            return NotFound();
        }

        return View(logVisit);
    }

    // POST: LogVisits/Delete/5
    [HttpDelete("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var logVisit = await _context.LogVisits.FindAsync(id);
        _context.LogVisits.Remove(logVisit);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LogVisitExists(int id)
    {
        return _context.LogVisits.Any(e => e.Id == id);
    }
}
