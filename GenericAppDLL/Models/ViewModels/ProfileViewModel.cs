using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public CustomerViewModel profileDetails { get; set; } = new CustomerViewModel();
        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
        public List<JournalViewModel> Journals { get; set; } = new List<JournalViewModel>();
        public List<MeetupViewModel> Meetups { get; set; } = new List<MeetupViewModel>();
        public List<CustomerViewModel> Friends { get; set; } = new List<CustomerViewModel>();
        public List<PointsViewModel> Transactions { get; set; } = new List<PointsViewModel>();
        public int TotalPoints { get; set; }
    }
}
