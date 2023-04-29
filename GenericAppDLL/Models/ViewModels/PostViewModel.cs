using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public string SenderGuid { get; set; } = string.Empty;
        public string RecieverGuid { get; set; } = string.Empty;
        public string PostGuid { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string GroupGuid { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Feature { get; set; }
        public int Interactions { get; set; }
        public string AttatchmentPath { get; set; } = string.Empty;
        public IFormFile Attachment { get; set; }
        public PostFooterViewModel postFooter { get; set; } = new PostFooterViewModel();
    }
}
