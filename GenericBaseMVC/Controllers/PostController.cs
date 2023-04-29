using GenericBaseMVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace GenericBaseMVC.Controllers;

[Authorize]
public class PostController : Controller
{
    private IHostEnvironment _hostingEnvironment;
    public PostService _PostService { get; set; }
    public PostInteractionService _postInteractionService { get; set; }

    public PostController(IHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        _PostService = new PostService();
        _postInteractionService = new PostInteractionService();
    }

    public async Task<List<PostViewModel>> GetAllPosts(string currentCustomer) {

        var model = new FeedViewModel();
        var AllPostsDTO = await _PostService.GetAll();
        var AllPostVM = new List<PostViewModel>();

        foreach (var post in AllPostsDTO)
        {

            var postInteractions = await _postInteractionService.Get(post.ModelGuid);
            PostFooterViewModel footer = new PostFooterViewModel();
            footer.NumLikes = postInteractions.Where(m => m.Status == 2).Count();
            footer.NumComments = postInteractions.Where(m => m.Status == 3).Count();
            footer.LastComments = postInteractions.Where(m => m.Status == 3).FirstOrDefault() != null ? postInteractions.Where(m => m.Status == 2).FirstOrDefault().Caption :  "Enter A Comment";

            //footer.comments = ;

            footer.postInteraction = new PostInteractionViewModel()
            {
                SenderGuid = currentCustomer,
                PostGuid = post.ModelGuid,

            };

            PostViewModel newEntity = new PostViewModel
            {
                SenderGuid = post.SenderGuid,
                AttatchmentPath = post.AttatchmentPath,
                Caption = post.Caption,
                Feature = post.Feature,
                GroupGuid = post.GroupGuid,
                Interactions = post.Interactions,
                Message = post.Message,
                RecieverGuid = post.RecieverGuid,
                postFooter = footer,         
                PostGuid = post.ModelGuid
            };
            newEntity.AttatchmentPath = newEntity.AttatchmentPath.Split("root\\")[1];

            AllPostVM.Add(newEntity);

        }

        return AllPostVM;
    }

    public async Task<IActionResult> Index()
    {
        var AllPostsDTO = await  _PostService.GetAll();
        var model = new ViewListPostViewModel();

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

        var AllPostVM = await GetAllPosts(currentCustomer.ModelGuid);

        model.posts = AllPostVM;

        model.settings.SelectedTheme = currentCustomer.SelectedTheme;


        return View(AllPostVM);
    }

    public async Task<IActionResult> Feed()
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name; 
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        var model = new FeedViewModel();

        var AllPostVM = GetAllPosts(currentCustomer.ModelGuid);

        model.Posts = await AllPostVM;
        model.settings.SelectedTheme = "Mint";

        model.settings.SelectedTheme = currentCustomer.SelectedTheme;
        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = new CreatePostViewModel();

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings.SelectedTheme = currentCustomer.SelectedTheme;

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostViewModel model)
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await new CustomerService().Get(email)).FirstOrDefault();

        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        //create folder if not exist
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        //get file extension
        FileInfo fileInfo = new FileInfo(model.Attatchment.FileName);
        string fileName = model.Attatchment.FileName + Guid.NewGuid().ToString() + fileInfo.Extension;

        string fileNameWithPath = Path.Combine(path, fileName);

        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
        {
            model.Attatchment.CopyTo(stream);
        }

        var Dto = new CreatePostDto() { 
        SenderGuid = currentCustomer.ModelGuid,
        AttatchmentPath =fileNameWithPath,
        Caption = model.Caption,
        Feature = 1,
        GroupGuid = "Post",
        Interactions = 0,
        Message= model.Message,
        RecieverGuid = "Post"
            
        };

        await _PostService.Create(Dto);

        return View();
    }
}
