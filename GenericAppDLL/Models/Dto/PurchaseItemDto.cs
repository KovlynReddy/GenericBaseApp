using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class PurchaseItemDto
    {
        public string DatePurchased { get; set; } = string.Empty;
        public string ItemGuid { get; set; } = string.Empty;
        public string CartId { get; set; } = string.Empty;
        public int IsPaid { get; set; }
        public string ModelGuid { get; set; } = string.Empty;
    }
}
