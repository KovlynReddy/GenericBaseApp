namespace GenericAppDLL.Models.Dto;

public class MeetUpDto
{
    public string SenderGuid { get; set; }
    public string RecieverGuid { get; set; }
    public string Lat { get; set; }
    public string lon { get; set; }
    public string DateTimeSent { get; set; }
    public string DateTimeRecieved { get; set; }
    public string DateTimeResponded { get; set; }

    public int Status { get; set; }
    public string Caption { get; set; }
    public string ModelGuid { get; set; }
}
