using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class CommentViewModel
    {
        public string CommentGuid { get; set; }
        public string SenderGuid { get; set; }
        public string SenderProfilePicture { get; set; }
        public string SentDateTime { get; set; }
        public string Comment { get; set; }
    }
}
