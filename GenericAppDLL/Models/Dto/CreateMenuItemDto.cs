namespace GenericAppDLL.Models.Dto;

public class CreateMenuItemDto : BaseDto
{
    public string ItemName { get; set; }
    public string MenuId { get; set; }
    public string SKUCode { get; set; }
    public string Caption { get; set; }
    public int Cost { get; set; }
    public string Currency { get; set; }
    public string CreatorId { get; set; }
    public IFormFile ItemImage { get; set; }
}
