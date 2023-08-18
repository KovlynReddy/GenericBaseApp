﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.DomainModel
{
    public class Advert : BaseModel
    {
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Hyperlink { get; set; } = string.Empty;
        public string ImagePath01 { get; set; } = string.Empty;
        public string ImagePath02 { get; set; } = string.Empty;
        public string ImagePath03 { get; set; } = string.Empty;
        public string ImagePath04 { get; set; } = string.Empty;
        public string VideoPath01 { get; set; } = string.Empty;
        public string Gif01 { get; set; } = string.Empty;
        public int Tyoe { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
