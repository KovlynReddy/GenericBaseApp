using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class PostHeaderViewModel : BaseViewModel
    {
        public bool IsProfileView { get; set; } = false;
        public ProfileHeaderViewModel SenderDetails { get; set; }
    }
}
