using AutoMapper;
using GenericAppDLL.Models.DomainModel;
using GenericBaseMVC.Handlers;
using GenericBaseMVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace GenericBaseMVC.Controllers;

[Authorize]
public class PostController : Controller
{
    private IHostEnvironment _hostingEnvironment;
    private readonly IMapper mapper;

    public PostService _PostService { get; set; }
    public PostInteractionService _postInteractionService { get; set; }

    public PostController(IHostEnvironment hostingEnvironment , IMapper mapper)
    {
        _hostingEnvironment = hostingEnvironment;
        this.mapper = mapper;
        _PostService = new PostService();
        _postInteractionService = new PostInteractionService();
    }

    public async Task<IActionResult> Index()
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        var AllPostsDTO = await  _PostService.GetAll(currentCustomer.ModelGuid);
        var model = new ViewListPostViewModel();

        var AllPostVM = await PostHandler.GetAllPosts(currentCustomer.ModelGuid);

        model.posts = AllPostVM;

        model.settings = await SettingsHandler.GetSettings(email);


        return View(AllPostVM);
    }

    public async Task<IActionResult> Feed()
    {
        var _customerService = new CustomerService();
        var email = User.Identity.Name; 
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        var model = new FeedViewModel();

        var numNotifications = await NotificationHandler.GetNotifications(currentCustomer.ModelGuid);
        
        var AllPostVM = await PostHandler.GetAllPosts(currentCustomer.ModelGuid);

        foreach (var post in AllPostVM)
        {
            // add notification ----------------------------------------------------

            var postInteractions = (await _postInteractionService.Get(post.PostGuid)).Where(m => m.Type == 5 && m.UserGuid == currentCustomer.ModelGuid).ToList();
            
            //if (postInteractions.Count < 1)
            //{
            //    var newComment = new PostInteractionDto()
            //    {
            //        PostGuid = post.PostGuid,
            //        UserGuid = currentCustomer.ModelGuid,
            //        Type = 5,
            //        Status = 1,
            //        SenderName = currentCustomer.CustomerName,
            //        SenderGuid = currentCustomer.ModelGuid,
            //        SentDateTime = DateTime.Now.ToString()
            //    };
            //    var dto = mapper.Map<CreatePostInteractionDto>(newComment);

            //    await _postInteractionService.Create(dto);

            //}
        }

        model.Posts = AllPostVM;
        model.settings.SelectedTheme = "Mint";

        model.settings = await SettingsHandler.GetSettings(email);
        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = new CreatePostViewModel();

        var _customerService = new CustomerService();
        var email = User.Identity.Name;
        var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
        model.settings = await SettingsHandler.GetSettings(email);

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

        var points = new PointsDto() { 
            AccountGuid = currentCustomer.AccountGuid,
            Description = "Post Created",
            Type = 3,
            SenderType = 3,
            UserGuid  = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            Amount = 150,
            CreatedDateTime = DateTime.Now.ToString(),            
        };

        await new PointsService().Post(points);

        return RedirectToAction("Feed");
    }
}
