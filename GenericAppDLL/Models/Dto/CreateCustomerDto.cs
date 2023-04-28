namespace GenericAppDLL.Models.Dto;

public class CreateCustomerDto : BaseDto
{
    public string CustomerName { get; set; } =  string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string DOB { get; set; } = string.Empty;
    // public IFormFile UploadedImage { get; set; }
    public string ProfileImagePath { get; set; } = string.Empty;

}
