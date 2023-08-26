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

        [Route("~/api/advertisment/{email}")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string? email)
        {
            return Ok(await _db.Get());
        }

        [Route("~/api/advertisment/CreateDto")]
        [HttpPost]
        public async Task<IActionResult> Post(AdvertisingDto dto)
        {
            var results = await _db.Post(dto);

            return Ok(results);
        }
    }
}
