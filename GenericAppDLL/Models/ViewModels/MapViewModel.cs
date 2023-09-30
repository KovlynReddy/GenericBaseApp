namespace GenericAppDLL.Models.ViewModels;

public class MapViewModel : BaseViewModel
{
    public List<string> Lats { get; set; } = new List<string>();
    public List<string> Longs { get; set; } = new List<string>();
    public List<string> Captions { get; set; } = new List<string>();
    public List<string> Names { get; set; } = new List<string>();
    public List<string> ids { get; set; } = new List<string>();

    public string CenterLat { get; set; }
    public string CenterLon { get; set; }
    public string Scale { get; set; }
    public string Zoom { get; set; }

    public List<MapMark> MapMarks { get; set; } = new List<MapMark>();
}

public class CreateMeetupMapViewModel : MapViewModel {
    public CreateMeetUpViewModel newMeetup { get; set; } = new CreateMeetUpViewModel();

}

public class CreateBookingMapViewModel : MapViewModel {
    public CreateBookingViewModel newBooking { get; set; } = new CreateBookingViewModel();

}

public class MapMark {

    public string Lat { get; set; }
    public string Lon { get; set; }
    public string Caption { get; set; }
    public string Name { get; set; }

}


