namespace GenericAppDLL.Models.ViewModels;

public class CreateMenuItemViewModel : BaseViewModel
{
    public string ItemName { get; set; } = string.Empty;
    public string MenuId { get; set; }    = string.Empty;
    public string SKUCode { get; set; }   = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public int Cost { get; set; }
    public string Currency { get; set; }            = string.Empty;
    public string CreatedDateTime { get; set; }     = string.Empty;
    public string CreatorId { get; set; }           = string.Empty;
    public string VendorId { get; set; } = string.Empty;
    //public IFormFile ItemImage { get; set; }
}
