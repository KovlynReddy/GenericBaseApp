namespace GenericAppDLL.Models.ViewModels;

public class CreateBookingViewModel : BaseViewModel
{
    public DateTime BookingDate { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime BookingDateTime { get; set; }
    public string Reason { get; set; }
    public string Request { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }

    public string SelectedVendor { get; set; }
    public List<string> Vendors { get; set; } = new List<string>();
    public string CustomerGuid { get; set; }
}
