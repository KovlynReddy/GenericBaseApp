namespace GenericAppDLL.Models.Dto;

public class SignalRMessage
{
    public int UserId { get; set; }
    public int MeetingId { get; set; }
    public int ItemId { get; set; }
    public string Message { get; set; } = string.Empty;
    public int Code { get; set; }
}
