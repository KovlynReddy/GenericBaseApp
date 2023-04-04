using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ChatHeaderViewModel
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string RecieverName { get; set; } = string.Empty;
        public int ChatId { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
