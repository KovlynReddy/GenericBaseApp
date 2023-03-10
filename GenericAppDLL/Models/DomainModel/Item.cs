namespace GenericAppDLL.Models.DomainModel;

public class Item : BaseModel
{
    public string ItemName { get; set; }  = string.Empty;
    public string MenuId { get; set; }    = string.Empty;
    public string SKUCode { get; set; }   = string.Empty;
    public string Caption { get; set; }   = string.Empty;
    public int Cost { get; set; }         
    public string Currency { get; set; }  = string.Empty;
    public string Path { get; set; } = string.Empty;
}
