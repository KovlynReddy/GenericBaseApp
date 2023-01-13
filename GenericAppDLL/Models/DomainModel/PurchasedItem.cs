namespace GenericAppDLL.Models.DomainModel;

public class PurchasedItem : BaseModel
{
    public string DatePurchased { get; set; }       = string.Empty;
    public string ItemGuid { get; set; }            = string.Empty;
    public string CartId { get; set; } = string.Empty;
}
