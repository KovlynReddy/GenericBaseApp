﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.ViewModels
{
    public class SendDirectMessageViewModel
    {
        public int SenderId { get; set; }
        public int MeetingId { get; set; }
        public int ItemId { get; set; }
        public string SenderGuid { get; set; } = string.Empty;
        public string MeetingGuid { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Attachment { get; set; } = string.Empty;
    }
}