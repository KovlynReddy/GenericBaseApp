﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class MenuItemViewModel : BaseViewModel
    {

        public string ItemName { get; set; }
        public string MenuId { get; set; }
        public string SKUCode { get; set; }
        public string ModelGUID { get; set; }
        public string VendorGuid { get; set; }
        public string Caption { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
        public int IsMod { get; set; }
        public string Currency { get; set; }
        public string CreatorId { get; set; }
        public string ItemImage { get; set; }
        public Decimal AverageRating { get; set; }
        public int AverageRatingInt { get; set; }
    }
}
