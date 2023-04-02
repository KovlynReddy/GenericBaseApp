namespace GenericAppDLL.Models.Dto;

public class BaseDto
{
    public int Id { get; set; }
    public string CreatedDateTimeString { get; set; }       =  string.Empty;
    public string ArrivedDateTimeString { get; set; }       =  string.Empty;
    public string BookDateTimeString { get; set; }          =  string.Empty;
    public string CompletedDateTimeString { get; set; } = string.Empty;
    public DateTime CreatedDateTime { get; set; }
    public DateTime ArrivedDateTime { get; set; }
    public DateTime BookDateTime { get; set; }
    public DateTime CompletedDateTime { get; set; } 
    public int IsDeleted { get; set; }
    public string ModelGuid { get; set; }        =  string.Empty;
    public string CreatorGuid { get; set; }      =  string.Empty;
    public string UserGuid { get; set; }         =  string.Empty;
    public string BarberGuid { get; set; } = string.Empty;
}
