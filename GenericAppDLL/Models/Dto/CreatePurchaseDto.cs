using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class CreatePurchaseDto
    {
        public int Total { get; set; }
        public string DatePurchased { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string CartId { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public int IsPaid { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
        public string ModelGuid { get; set; } = string.Empty;
    }
}
