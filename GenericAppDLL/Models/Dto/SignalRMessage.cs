namespace GenericAppDLL.Models.Dto;

public class SignalRMessage
{
    public string RecieverId { get; set; } = string.Empty;
    public string SenderId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Attachment { get; set; } = string.Empty;
    public int Code { get; set; }
}
