using GenericBaseMVC.Services;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Cryptography;

namespace GenericBaseMVC.Handlers
{
    public static class SettingsHandler
    {
        public static async Task<SettingsImplementationViewModel> GetSettings(string email, bool enableSideAdverts = false)
        {
            var _customerService = new CustomerService();
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var model = new SettingsImplementationViewModel();
            var numNotifications = await NotificationHandler.GetNotifications(currentCustomer.ModelGuid);

            model.SelectedTheme = currentCustomer.SelectedTheme;
            model.NumNotifcations = numNotifications.NumNotifcations;

            model.EnableSideAdvert = enableSideAdverts;
            model.sideAdverts = await GetAdvertisments(email);

            return model;
        }

        public static async Task<List<SideAdvertViewModel>> GetAdvertisments(string email) {
            var adverts = new List<SideAdvertViewModel>();
            var advertDtos = await new AdvertisingService().Get(email);

            foreach (var advertDto in advertDtos)
            {
                adverts.Add(await ToSideViewModel(advertDto));
            }

            adverts.Shuffle();

            return adverts;
        }

        private static async Task<SideAdvertViewModel> ToSideViewModel(AdvertisingDto dto)
        {
            return new SideAdvertViewModel()
            {
                Description = dto.Description,
                ImagePath01 = dto.ImagePath01,
                ImagePath02 = dto.ImagePath02,
                ImagePath03 = dto.ImagePath03,
                ImagePath04 = dto.ImagePath04,
                Caption = dto.Caption,
                VideoPath01 = dto.VideoPath01,
                Hyperlink = dto.Hyperlink,
                Type = dto.Type,
                Gif01 = dto.Gif01,
                CompletionDate = dto.CompletionDate,
                StartingDate = dto.StartingDate
            };
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
