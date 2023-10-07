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

    [HttpGet]
    [Route("~/api/Vendor/Index")]
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
        result.Reverse();

        return Ok(result);
    }

    [HttpGet]
    [Route("~/api/Vendor/Details")]
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

    [HttpGet]
    [Route("~/api/Vendor/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Vendors.ToListAsync();

        result.Reverse();

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("~/api/Vendor")]
    public async Task<IActionResult> Post([FromBody]CreateVendorDto Vendor)
    {
        Address newAddress = new Address()
        {
            Lat = Vendor.Lat,
            lon = Vendor.Lon,
            ModelGUID = Guid.NewGuid().ToString()
        };

        Vendor newVendor = new Vendor
        {
            VendorEmail = Vendor.VendorEmail,//
            VendorName = Vendor.VendorName,//
            ModelGUID = Guid.NewGuid().ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            AverageRating = "",
            AddressGuid = newAddress.ModelGUID,
            Status = 0 ,
            VendorImage = Vendor.VendorImage
        };

        _context.Add(newAddress);
        _context.Add(newVendor);

        await _context.SaveChangesAsync();
        return Ok(newVendor);
    }

    [HttpDelete]
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

    private bool VendorExists(int id)
    {
        return _context.Vendors.Any(e => e.Id == id);
    }
}
