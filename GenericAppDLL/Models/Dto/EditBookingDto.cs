namespace GenericAppDLL.Models.Dto;

public class EditBookingDto : BaseDto
{ 
    public string CreatedDateTime { get; set; }
    public string ArrivedDateTime { get; set; }
    public string BookDateTime { get; set; }
    public string CompletedDateTime { get; set; }
}
