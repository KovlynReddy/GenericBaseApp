namespace GenericAppDLL.Models.Dto;

public class CreateBookingDto : BaseDto
{
    public DateTime BookingDate { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime BookingDateTime { get; set; }
    public string Reason { get; set; }
    public string Request { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
}
