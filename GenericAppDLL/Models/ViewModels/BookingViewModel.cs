namespace GenericAppDLL.Models.ViewModels;

public class BookingViewModel
{
    public string CreatedDateTimeString { get; set; }
    public string ArrivedDateTimeString { get; set; }
    public string BookDateTimeString { get; set; }
    public string CompletedDateTimeString { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime ArrivedDateTime { get; set; }
    public DateTime BookDateTime { get; set; }
    public DateTime CompletedDateTime { get; set; }
    public int IsDeleted { get; set; }
    public string ModelGuid { get; set; }
    public string UserGuid { get; set; }
    public string VendorGuid { get; set; }
}

