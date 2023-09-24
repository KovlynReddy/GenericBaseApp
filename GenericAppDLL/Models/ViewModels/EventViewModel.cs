using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class EventViewModel
    {
        public int id { get; set; }
        public string meetupId { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
