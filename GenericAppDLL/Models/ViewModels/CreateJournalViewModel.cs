using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class CreateJournalViewModel : BaseViewModel
    {
        public string UserGuid { get; set; } = string.Empty;
        public string ItemGuid { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<IFormFile> uploads { get; set; } = new List<IFormFile>();
        public List<string> uploadPaths { get; set; } = new List<string>();
        public string Body { get; set; } = string.Empty;
    }
}
