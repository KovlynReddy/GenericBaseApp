using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class PurchaseCartDto
    {
        public string CartId { get; set; }
        public int Type { get; set; }
        public string OwnerGuid { get; set; }
    }
}
