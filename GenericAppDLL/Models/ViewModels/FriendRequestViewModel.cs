using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class FriendRequestViewModel : BaseViewModel
    {
        public IFormFile? UploadedImage { get; set; }
        public string ProfileImagePath { get; set; } = string.Empty;
        public string ModelGUID { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string DOBString { get; set; } = string.Empty;
        public DateOnly DOB { get; set; } = new DateOnly();
        public int Status { get; set; }
        public string RelationshipGuid { get; set; } = string.Empty;
        public string SenderGuid { get; set; } = string.Empty;
    }
}
