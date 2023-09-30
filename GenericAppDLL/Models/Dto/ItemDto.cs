﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class ItemDto : BaseDto
    {
        public string ItemName { get; set; } = string.Empty;
        public string MenuId { get; set; } = string.Empty;

        public string VendorId { get; set; } = string.Empty;
        public string SKUCode { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public int Cost { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
}
