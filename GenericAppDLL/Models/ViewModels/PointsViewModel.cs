using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class PointsViewModel : BaseViewModel
    {
        public string UserGuid { get; set; } = string.Empty;
        public string AccountGuid { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; } = string.Empty;
        public int Type { get; set; }
        public int SenderType { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}
