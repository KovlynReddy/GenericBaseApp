namespace GenericAppDLL.Models.ViewModels;

public class  CreateBookingViewModel
{
    public DateTime BookingDate { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime BookingDateTime { get; set; }
    public string Reason { get; set; }
    public string Request { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }

    public string SelectedBarber { get; set; }
    public List<string> Barbers { get; set; } = new List<string>();
    public string CustomerGuid { get; set; }
}
