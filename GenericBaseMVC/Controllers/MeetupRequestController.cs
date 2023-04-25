using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    public class MeetupRequestController : Controller
    {
        public async Task<IActionResult> Get()
        {
            return View();
        }
        public async Task<IActionResult> Get(string id)
        {
            return View();
        }
        public async Task<IActionResult> Post()
        {
            return View();
        }
        public async Task<IActionResult> Put()
        {
            return View();
        }
    }
}
