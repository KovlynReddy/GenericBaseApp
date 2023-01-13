namespace GenericAppDLL.Models.DomainModel;

public class BaseModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ModelGUID { get; set; } = string.Empty;
    public int IsDeleted { get; set; }
    [Required]
    public string CreatedDateTime { get; set; } = string.Empty;
    public string DeletedDateTime { get; set; } = string.Empty;
    public string CompletedDateTime { get; set; } = string.Empty;
    public string CreatorId { get; set; } = string.Empty;
}

