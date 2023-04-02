using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Dto;

public class DirectMessageDto
{
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }

    public string MeetingGuid { get; set; } = string.Empty;
    public string UserGuid { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
