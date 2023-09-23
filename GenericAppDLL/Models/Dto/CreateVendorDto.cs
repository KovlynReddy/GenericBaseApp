namespace GenericAppDLL.Models.Dto;

public class CreateVendorDto
{
    public string VendorEmail { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string AddressGuid { get; set; } = string.Empty;
    public string VendorImage { get; set; } = string.Empty;
    public string Lat { get; set; } = string.Empty;
    public string Lon { get; set; } = string.Empty;
}
