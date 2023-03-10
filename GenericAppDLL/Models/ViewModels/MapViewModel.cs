namespace GenericAppDLL.Models.ViewModels;

public class MapViewModel
{
    public List<string> Lats { get; set; } = new List<string>();
    public List<string> Longs { get; set; } = new List<string>();
    public List<string> Captions { get; set; } = new List<string>();
    public List<string> Names { get; set; } = new List<string>();

    public string CenterLat { get; set; }
    public string CenterLon { get; set; }
    public string Scale { get; set; }
    public string Zoom { get; set; }
}

public class MapMark {

    public string Lat { get; set; }
    public string Lon { get; set; }
    public string Caption { get; set; }
    public string Name { get; set; }

}


