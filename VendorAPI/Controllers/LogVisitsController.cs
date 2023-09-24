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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.LogVisits.ToListAsync());
    }

    [HttpGet]
    [Route("~/api/Visits/Details/{id}")]
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

    private bool LogVisitExists(int id)
    {
        return _context.LogVisits.Any(e => e.Id == id);
    }
}
