namespace VendorAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class VendorController : Controller
{
    private readonly VendorContext _context;

    public VendorController(VendorContext context)
    {
        _context = context;
    }

    // GET: Barbers
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Vendor> vendors = new List<Vendor>();
        vendors.Add(new Vendor { Id = 1, VendorName = "Barber1", VendorEmail = "barber1@gmail.com", AddressGuid = "A1111", AverageRating = "10", Status = 0, CreatedDateTime = new DateTime().ToString(), CreatorId = "C1111", ModelGUID = "B1111", IsDeleted = 0 });
        vendors.Add(new Vendor { Id = 2, VendorName = "Barber2", VendorEmail = "barber2@gmail.com", AddressGuid = "A2222", AverageRating = "1", Status = 0, CreatedDateTime = new DateTime().ToString(), CreatorId = "C2222", ModelGUID = "B2222", IsDeleted = 0 });

        //_context.Barbers.AddRange(barbers);
        //_context.SaveChanges();

        var result = await _context.Vendors.ToListAsync();
        result.AddRange(vendors);

        HttpResponseMessage response = new HttpResponseMessage();
        response.StatusCode = System.Net.HttpStatusCode.OK;
        //response.Content = result;

        return Ok(result);
    }

    // GET: Barbers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barber = await _context.Vendors
            .FirstOrDefaultAsync(m => m.Id == id);
        if (barber == null)
        {
            return NotFound();
        }

        return View(barber);
    }



    [AllowAnonymous]
    [Route("~/api/Barbers/Create")]
    [Route("~/api/Barbers/Create/{VendorEmail}/{VendorName}")]
    //[Route("api/Barbers/Create?BarberEmail={BarberEmail}&BarberName={BarberName}")]
    [HttpPost]
    public async Task<IActionResult> Create( string VendorEmail, string VendorName)//[FromBody]CreateBarberDto barber)
    {
        Vendor newBarber = new Vendor
        {
            VendorEmail = VendorEmail,//barber.BarberEmail,//
            VendorName = VendorName,//barber.BarberName,//
            ModelGUID = new Guid().ToString(),
            CreatedDateTime = new DateTime().ToString()
        };
            _context.Add(newBarber);
            await _context.SaveChangesAsync();
            return Ok(newBarber);
    }

    [HttpGet]
    [Route("~/api/Barbers/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Vendors.ToListAsync();

        return Ok(result);
    }

    [AllowAnonymous]
    [Route("~/api/Barbers/CreateDto")]
    [Route("~/api/Barbers/CreateDto/{BarberEmail}/{BarberName}")]
    //[Route("api/Barbers/Create?BarberEmail={BarberEmail}&BarberName={BarberName}")]
    [HttpPost]
    public async Task<IActionResult> CreateDto([FromBody]CreateVendorDto barber)
    {
        Vendor newBarber = new Vendor
        {
            VendorEmail = barber.VendorEmail,//
            VendorName = barber.VendorName,//
            ModelGUID = Guid.NewGuid().ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            AverageRating = "",
            AddressGuid = "",
            Status = 0 
        };
        _context.Add(newBarber);
        await _context.SaveChangesAsync();
        return Ok(newBarber);
    }

    // GET: Barbers/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barber = await _context.Vendors.FindAsync(id);
        if (barber == null)
        {
            return NotFound();
        }
        return View(barber);
    }

    [HttpGet]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BarberName,AddressGuid,AverageRating,Status,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Vendor barber)
    {
        if (id != barber.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(barber);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberExists(barber.Id))
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
        return View(barber);
    }

    // GET: Barbers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barber = await _context.Vendors
            .FirstOrDefaultAsync(m => m.Id == id);
        if (barber == null)
        {
            return NotFound();
        }

        return View(barber);
    }

    // POST: Barbers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var barber = await _context.Vendors.FindAsync(id);
        _context.Vendors.Remove(barber);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BarberExists(int id)
    {
        return _context.Vendors.Any(e => e.Id == id);
    }
}
