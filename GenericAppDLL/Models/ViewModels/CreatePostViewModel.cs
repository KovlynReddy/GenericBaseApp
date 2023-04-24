using Microsoft.AspNetCore.Http;

namespace GenericAppDLL.Models.ViewModels;

public class CreatePostViewModel : BaseViewModel
{
    public string SenderGuid { get; set; } = string.Empty;
    public string RecieverGuid { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string GroupGuid { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public int Feature { get; set; }
    public int Interactions { get; set; }
    public IFormFile? Attatchment { get; set; } 
    public string AttatchmentPath { get; set; } = string.Empty;

}
