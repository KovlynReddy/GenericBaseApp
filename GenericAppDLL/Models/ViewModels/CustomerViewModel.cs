namespace GenericAppDLL.Models.ViewModels;

public class CustomerViewModel : BaseViewModel
{
    public IFormFile? UploadedImage { get; set; }
    public string ProfileImagePath { get; set; } = string.Empty;
    public string ModelGUID { get; set; } = string.Empty;
    public string CreatedDateTime { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string DOBString { get; set; } = string.Empty;
    public DateOnly DOB { get; set; } = new DateOnly();
    public int IsFriend { get; set; }
    public string AccountGuid { get; set; } = string.Empty;
    public string LastTotal { get; set; } = string.Empty;
}
