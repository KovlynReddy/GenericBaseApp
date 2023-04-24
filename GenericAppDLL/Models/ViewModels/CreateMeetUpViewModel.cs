namespace GenericAppDLL.Models.ViewModels;

public  class CreateMeetUpViewModel : BaseViewModel
{
    public List<(string,string)> ListPeople { get; set; }
    public (string,string) SelectedPerson { get; set; }

    public string SenderGuid { get; set; }
    public string RecieverGuid { get; set; }
    public string Lat { get; set; }
    public string lon { get; set; }
    public string DateTimeSent { get; set; }
    public string DateTimeRecieved { get; set; }
    public string DateTimeResponded { get; set; }

    public int Status { get; set; }
    public string Caption { get; set; }
    public string ModelGuid { get; set; }
}
