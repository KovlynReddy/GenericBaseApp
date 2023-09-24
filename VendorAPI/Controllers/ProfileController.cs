namespace VendorAPI.Controllers;

public class ProfileController : Controller
{
    private readonly VendorContext _context;

    public ProfileController(VendorContext context)
    {
        _context = context;
    }

    [HttpGet("GetMyProfile/{ProfileId}")]
    public async Task<IActionResult> GetMyProfile(string ProfileId) {

        var response = _context.Customers.ToList().FirstOrDefault(m=>m.ModelGUID == ProfileId || m.CustomerEmail == ProfileId || m.UserId == ProfileId);

        return Ok(response);
    }

    [HttpGet("Index")]
    public IActionResult Index()
    {
        return View();
    }
}
