using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public  class PostDto
    {
        public string SenderGuid { get; set; } = string.Empty;
        public string RecieverGuid { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string GroupGuid { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Feature { get; set; }
        public int Interactions { get; set; }
        public IFormFile? Attatchment { get; set; }
        public string AttatchmentPath { get; set; } = string.Empty;

    }
}
