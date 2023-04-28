﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class JournalViewModel : BaseViewModel
    {
        public string UserGuid { get; set; } = string.Empty;
        public string ItemGuid { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<IFormFile> uploads { get; set; } = new List<IFormFile>();
        public string uploadPaths { get; set; } = string.Empty;
        public List<string> uploadPathsList { get; set; } = new List<string>();
        public string Body { get; set; } = string.Empty;
    }
}
