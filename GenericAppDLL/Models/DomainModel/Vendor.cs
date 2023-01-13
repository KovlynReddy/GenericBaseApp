namespace GenericAppDLL.Models.DomainModel;

public class Vendor : BaseModel
{
    [Required]
    public string VendorName { get; set; }       = string.Empty;
    [Required]                                   
    public string VendorEmail { get; set; }      = string.Empty;
    public string AddressGuid { get; set; }      = string.Empty;
    public string AverageRating { get; set; } = string.Empty;
    public int Status { get; set; }
}
