using Microsoft.Extensions.Hosting;

namespace GenericAppDLL.Models.DomainModel;

public class Purchase : BaseModel
{
    public int Total { get; set; }
    public string DatePurchased { get; set; }      = string.Empty;
    public string Currency { get; set; }           = string.Empty;
    public string CartId { get; set; } = string.Empty;
}
