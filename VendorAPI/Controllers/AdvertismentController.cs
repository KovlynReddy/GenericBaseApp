using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertismentController : Controller
    {
        private readonly VendorContext _context;
        private readonly IAdvertsDB _db;

        public AdvertismentController(VendorContext context, IAdvertsDB db)
        {
            _context = context;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? email)
        {
            return View(await _context.Adverts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateVendorDto dto)
        {
            await _db.Post(dto);
            return View();
        }
    }
}
