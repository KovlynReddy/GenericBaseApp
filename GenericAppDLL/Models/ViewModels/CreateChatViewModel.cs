using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class CreateChatViewModel
    {
        public int ChatTypeId { get; set; }
        public int CreatorId { get; set; }
        public int ChatName { get; set; }
    }
}
