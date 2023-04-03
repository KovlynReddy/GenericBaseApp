using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.DomainModel
{
    public class DirectMessage : BaseModel
    {
        public string SenderGuid { get; set; } = string.Empty;
        public string RecieverGuid { get; set; } = string.Empty;
        public string GroupGuid { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string AttatchmentString { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Read { get; set; }
    }
}
