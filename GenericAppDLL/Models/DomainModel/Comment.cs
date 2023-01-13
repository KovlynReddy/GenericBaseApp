namespace GenericAppDLL.Models.DomainModel;

public class Comment : BaseModel
{
    public string PostGuid { get; set; }          = string.Empty;
    public string Interactions { get; set; }      = string.Empty;
    public string Text { get; set; }              = string.Empty;
    public string Caption { get; set; } = string.Empty;
}
