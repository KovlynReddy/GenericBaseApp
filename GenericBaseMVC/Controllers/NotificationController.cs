using AutoMapper;
using GenericBaseMVC.Constants;
using GenericBaseMVC.Handlers;
using GenericBaseMVC.Services;
using Humanizer;
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
        public async Task<IActionResult> Notifications()
        {
            var _postInteractionService = new PostInteractionService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var model = new NotificationsViewModel();
            // meetups near me which did not expire
            // friends posts not seen

            //var AllPostVM = await PostHandler.GetAllPosts(currentCustomer.ModelGuid);

            //foreach (var post in AllPostVM)
            //{
            //    // add notification ----------------------------------------------------

            //}

            //// messages read


            //var allMessagesDto = await DirectMessageService.Get(currentCustomer.ModelGuid);

            //foreach (var message in allMessagesDto)
            //{
            //    if (message.Read == 0 && message.RecieverGuid == currentCustomer.ModelGuid)
            //    {
            //        // add notification ----------------------------------------------------
            //    }
            //}

            model = await NotificationHandler.GetNotifications(email);
            model.settings = await SettingsHandler.GetSettings(email);

            return View(model);
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
            if (!string.IsNullOrEmpty(Theme.Themes.SelectedTheme))
            {

            customerDetails.SelectedTheme = Theme.Themes.SelectedTheme;
            }

            if (Theme.newProfile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(Theme.newProfile.FileName);
                string fileName = Theme.newProfile.FileName + Guid.NewGuid().ToString() + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Theme.newProfile.CopyTo(stream);
                }

                customerDetails.ProfileImagePath = fileName;//fileNameWithPath.Split("root\\")[1];
            }

            //var updatedCustomer = mapper.Map<CustomerDto>(customerDetails)

            await _customerService.Put(customerDetails);
            return RedirectToAction("Settings");
        }
    }
}
