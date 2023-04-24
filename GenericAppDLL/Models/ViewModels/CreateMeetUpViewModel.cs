namespace GenericAppDLL.Models.ViewModels;

public  class CreateMeetUpViewModel : BaseViewModel
{
    public List<(string,string)> ListPeople { get; set; }
    public (string,string) SelectedPerson { get; set; }

    public string SenderGuid { get; set; }        = string.Empty;
    public string RecieverGuid { get; set; }      = string.Empty;
    public string Lat { get; set; }               = string.Empty;
    public string lon { get; set; }               = string.Empty;
    public string DateTimeSent { get; set; }      = string.Empty;
    public string DateTimeRecieved { get; set; }  = string.Empty;
    public string DateTimeResponded { get; set; } = string.Empty;
    public int Status { get; set; }  
    public string Caption { get; set; }           = string.Empty;
    public string ModelGuid { get; set; } = string.Empty;
}
