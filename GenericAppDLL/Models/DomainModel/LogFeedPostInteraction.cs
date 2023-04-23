namespace GenericAppDLL.Models.DomainModel;

public class LogFeedPostInteraction : BaseModel
{

    public string InteractionGuid { get; set; }   = string.Empty;
    public string PostGuid { get; set; }          = string.Empty;
    public string InteractionId { get; set; }     = string.Empty;
    public string InteractionDate { get; set; } = string.Empty;
    public string UserGuid { get; set; } = string.Empty;
    public string PostOwnerGuid { get; set; } = string.Empty;

}
