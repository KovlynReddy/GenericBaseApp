namespace GenericAppDLL.Models.DomainModel;

public class Post : BaseModel
{                                                
    public string SenderGuid { get; set; }        = string.Empty;
    public string RecieverGuid { get; set; }      = string.Empty;
    public string Caption { get; set; }           = string.Empty;
    public string GroupGuid { get; set; }         = string.Empty;
    public string Message { get; set; }           = string.Empty;
    public int Feature { get; set; }             
    public int Interactions { get; set; }         
    public string AttatchmentPath { get; set; } = string.Empty;
    public string CreatedDateTime { get; set; } = string.Empty;
}
