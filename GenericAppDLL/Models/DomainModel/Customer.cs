namespace GenericAppDLL.Models.DomainModel;

public class Customer : BaseUser 
{
    [Required]
    public string CustomerName { get; set; } = string.Empty;
    [Required]                                     
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string ProfileImagePath { get; set; } = string.Empty;
    public string SelectedTheme { get; set; } = string.Empty;
    public string AccountGuid { get; set; } = string.Empty;
    public string LastTotal { get; set; } = string.Empty;
}
