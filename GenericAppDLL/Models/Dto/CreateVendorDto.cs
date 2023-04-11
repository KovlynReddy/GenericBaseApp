namespace GenericAppDLL.Models.Dto;

public class CreateVendorDto
{
    public string VendorEmail { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string AddressGuid { get; set; } = string.Empty;
}
