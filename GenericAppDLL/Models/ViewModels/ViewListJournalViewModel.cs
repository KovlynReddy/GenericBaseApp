using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class ViewListJournalViewModel : BaseViewModel
    {
        public string UserGuid { get; set; } = string.Empty;
        public List<JournalViewModel> journals { get; set; }
    }
}
