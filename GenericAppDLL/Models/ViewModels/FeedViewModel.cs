
namespace GenericAppDLL.Models.ViewModels;

public class FeedViewModel : BaseViewModel
{
    public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
}
