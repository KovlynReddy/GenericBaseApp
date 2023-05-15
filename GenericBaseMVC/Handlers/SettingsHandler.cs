using GenericBaseMVC.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GenericBaseMVC.Handlers
{
    public static class SettingsHandler
    {
        public static async Task<SettingsImplementationViewModel> GetSettings(string email)
        {
            var _customerService = new CustomerService();
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var model = new SettingsImplementationViewModel();
            var numNotifications = await NotificationHandler.GetNotifications(currentCustomer.ModelGuid);

            model.SelectedTheme = currentCustomer.SelectedTheme;
            model.NumNotifcations = numNotifications.NumNotifcations;

            return model;
        }
    }
}
