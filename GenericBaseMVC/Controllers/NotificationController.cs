using AutoMapper;
using GenericBaseMVC.Constants;
using GenericBaseMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IMapper mapper;

        public CustomerService _customerService { get; set; }
        public NotificationController(IMapper mapper)
        {
            _customerService = new CustomerService();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Notifications()
        {
            var userEmail = User.Identity.Name;

            // messages read
            // friends posts not seen
            // meetups near me which did not expire



            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Settings() {
            SettingsViewModel model = new SettingsViewModel();

            model.Themes.Themes = new Themes().themes;

            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            model.settings.SelectedTheme = currentCustomer.SelectedTheme;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSettings(SettingsViewModel Theme) {
            var email = User.Identity.Name;
            var customerDetails = (await _customerService.Get(email)).FirstOrDefault();
            customerDetails.SelectedTheme = Theme.Themes.SelectedTheme;

            //var updatedCustomer = mapper.Map<CustomerDto>(customerDetails)

            await _customerService.Put(customerDetails);
            return View();
        }
    }
}
