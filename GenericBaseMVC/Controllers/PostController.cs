namespace GenericBaseMVC.Controllers;

public class PostController : Controller
{
    private IHostEnvironment _hostingEnvironment;
    public PostService _PostService { get; set; }

    public PostController(IHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        _PostService = new PostService();
    }

    public async Task<IActionResult> Index()
    {
        var AllPostsDTO = await  _PostService.GetAll();
        var AllPostVM = new List<PostViewModel>();

        foreach (var post in AllPostsDTO)
        {
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
            };

            AllPostVM.Add(newEntity);

        }
        return View(AllPostVM);
    }

    public async Task<IActionResult> Feed()
    {
        var model = new FeedViewModel();
        var AllPostsDTO = await _PostService.GetAll();
        var AllPostVM = new List<PostViewModel>();

        foreach (var post in AllPostsDTO)
        {
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
            };
            newEntity.AttatchmentPath = newEntity.AttatchmentPath.Split("root\\")[1];

            AllPostVM.Add(newEntity);

        }
        model.Posts = AllPostVM;
        model.settings.SelectedTheme = "Mint";

        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostViewModel model)
    {

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
        SenderGuid = Guid.NewGuid().ToString(),
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
