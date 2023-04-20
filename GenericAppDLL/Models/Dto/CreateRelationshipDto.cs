using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto
{
    public class CreateRelationshipDto
    {
        public int Status { get; set; }
        public string SenderId { get; set; } = string.Empty;
        public string RecieverId { get; set; } = string.Empty;
        public string DateSent { get; set; } = string.Empty;
        public string DateReplied { get; set; } = string.Empty;
        public int Id { get; set; }
        public string ModelGUID { get; set; } = string.Empty;
        public int IsDeleted { get; set; }
        public string CreatedDateTime { get; set; } = string.Empty;
        public string DeletedDateTime { get; set; } = string.Empty;
        public string CompletedDateTime { get; set; } = string.Empty;
        public string CreatorId { get; set; } = string.Empty;
    }
}
