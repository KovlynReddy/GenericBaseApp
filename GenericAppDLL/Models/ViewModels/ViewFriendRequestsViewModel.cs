using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewFriendRequestsViewModel
    {
        public List<FriendRequestViewModel> users { get; set; } = new List<FriendRequestViewModel>();
    }
}
