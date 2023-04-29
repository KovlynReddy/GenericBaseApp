using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class PostFooterViewModel
    {
        public int NumLikes { get; set; }
        public int NumComments { get; set; }
        public string LastComments { get; set; }
        public List<CommentViewModel> comments { get; set; } = new List<CommentViewModel>();
        public PostInteractionViewModel postInteraction { get; set; } = new PostInteractionViewModel();
    }
}
