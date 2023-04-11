namespace GenericAppDLL.Models.DomainModel;

public class Deal : BaseModel
{
    [Required]
    public string VendorGuid { get; set; }    = string.Empty;
    public string Description { get; set; }   = string.Empty;
    public string StartDate { get; set; }     = string.Empty;
    public string EndDate { get; set; }       = string.Empty;
    public string Reason { get; set; }        = string.Empty;
    public int Percentage { get; set; }      
    public int Amount { get; set; }
}
