namespace GenericAppDLL.Models.DomainModel;

public class Relationship : BaseModel
{
    public int Status { get; set; }
    public string SenderId { get; set; }       = string.Empty;
    public string RecieverId { get; set; }     = string.Empty;
    public string DateSent { get; set; }       = string.Empty;
    public string DateReplied { get; set; } = string.Empty;
}
