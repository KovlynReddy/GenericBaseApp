using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.DomainModel
{
    public class DirectMessage : BaseModel
    {
        public string ChatName      { get; set; } = string.Empty;
        public string CreatorGuid      { get; set; } = string.Empty;
    }
}
