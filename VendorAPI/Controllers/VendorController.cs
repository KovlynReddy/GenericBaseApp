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

    // GET: Vendors
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Vendor> vendors = new List<Vendor>();
        vendors.Add(new Vendor { Id = 1, VendorName = "Vendor1", VendorEmail = "Vendor1@gmail.com", AddressGuid = "A1111", AverageRating = "10", Status = 0, CreatedDateTime = new DateTime().ToString(), CreatorId = "C1111", ModelGUID = "B1111", IsDeleted = 0 });
        vendors.Add(new Vendor { Id = 2, VendorName = "Vendor2", VendorEmail = "Vendor2@gmail.com", AddressGuid = "A2222", AverageRating = "1", Status = 0, CreatedDateTime = new DateTime().ToString(), CreatorId = "C2222", ModelGUID = "B2222", IsDeleted = 0 });

        //_context.Vendors.AddRange(Vendors);
        //_context.SaveChanges();

        var result = await _context.Vendors.ToListAsync();
        result.AddRange(vendors);

        HttpResponseMessage response = new HttpResponseMessage();
        response.StatusCode = System.Net.HttpStatusCode.OK;
        //response.Content = result;

        return Ok(result);
    }

    // GET: Vendors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Vendor = await _context.Vendors
            .FirstOrDefaultAsync(m => m.Id == id);
        if (Vendor == null)
        {
            return NotFound();
        }

        return View(Vendor);
    }



    //[AllowAnonymous]
    //[Route("~/api/Vendor/Create")]
    //[Route("~/api/Vendor/Create/{VendorEmail}/{VendorName}")]
    ////[Route("api/Vendors/Create?VendorEmail={VendorEmail}&VendorName={VendorName}")]
    //[HttpPost]
    //public async Task<IActionResult> Create( string VendorEmail, string VendorName)//[FromBody]CreateVendorDto Vendor)
    //{
    //    Vendor newVendor = new Vendor
    //    {
    //        VendorEmail = VendorEmail,//Vendor.VendorEmail,//
    //        VendorName = VendorName,//Vendor.VendorName,//
    //        ModelGUID = new Guid().ToString(),
    //        CreatedDateTime = new DateTime().ToString()
    //    };
    //        _context.Add(newVendor);
    //        await _context.SaveChangesAsync();
    //        return Ok(newVendor);
    //}

    [HttpGet]
    [Route("~/api/Vendor/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Vendors.ToListAsync();

        return Ok(result);
    }

    //[Route("api/Vendors/Create?VendorEmail={VendorEmail}&VendorName={VendorName}")]
    [AllowAnonymous]
    [HttpPost]
    [Route("~/api/Vendor")]
    public async Task<IActionResult> Post([FromBody]CreateVendorDto Vendor)
    {
        Vendor newVendor = new Vendor
        {
            VendorEmail = Vendor.VendorEmail,//
            VendorName = Vendor.VendorName,//
            ModelGUID = Guid.NewGuid().ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            AverageRating = "",
            AddressGuid = "",
            Status = 0 
        };
        _context.Add(newVendor);
        await _context.SaveChangesAsync();
        return Ok(newVendor);
    }

    // GET: Vendors/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Vendor = await _context.Vendors.FindAsync(id);
        if (Vendor == null)
        {
            return NotFound();
        }
        return View(Vendor);
    }

    [HttpGet]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VendorName,AddressGuid,AverageRating,Status,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Vendor Vendor)
    {
        if (id != Vendor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(Vendor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(Vendor.Id))
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
        return View(Vendor);
    }

    // GET: Vendors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Vendor = await _context.Vendors
            .FirstOrDefaultAsync(m => m.Id == id);
        if (Vendor == null)
        {
            return NotFound();
        }

        return View(Vendor);
    }

    // POST: Vendors/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var Vendor = await _context.Vendors.FindAsync(id);
        _context.Vendors.Remove(Vendor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VendorExists(int id)
    {
        return _context.Vendors.Any(e => e.Id == id);
    }
}
