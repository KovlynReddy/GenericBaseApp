using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewListPostViewModel : BaseViewModel
    {
        public List<PostViewModel> posts { get; set; } = new List<PostViewModel>();
    }
}
