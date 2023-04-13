using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class MenuItemViewModel
    {
        public string ItemName { get; set; }
        public string MenuId { get; set; }
        public string SKUCode { get; set; }
        public string ModelGUID { get; set; }
        public string Caption { get; set; }
        public int Cost { get; set; }
        public int IsMod { get; set; }
        public string Currency { get; set; }
        public string CreatorId { get; set; }
        public IFormFile ItemImage { get; set; }
    }
}
