using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    public class NotificationController : Controller
    {
        public NotificationController()
        {

        }

        public IActionResult Index()
        {
            var userEmail = User.Identity.Name;

            // messages read
            // friends posts not seen
            // meetups near me which did not expire



            return View();
        }
    }
}
