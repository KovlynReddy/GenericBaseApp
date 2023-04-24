using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewListBookingViewModel : BaseViewModel
    {
        public List<BookingViewModel> bookings { get; set; } = new List<BookingViewModel>();
    }
}
