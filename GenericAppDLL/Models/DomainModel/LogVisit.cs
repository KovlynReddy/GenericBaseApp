namespace GenericAppDLL.Models.DomainModel;

public class LogVisit : BaseModel
{
    public string BarberGuid { get; set; }        = string.Empty;
    public string UserGuid { get; set; }          = string.Empty;
    public string Reason { get; set; }            = string.Empty;
    public int Rating { get; set; }               
    public string Description { get; set; }       = string.Empty;
    public string BookingTime { get; set; }       = string.Empty;
    public string ArriveTime { get; set; }        = string.Empty;
    public string CompletionTime { get; set; } = string.Empty;

}
