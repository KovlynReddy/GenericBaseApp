using GenericAppDLL.Models.ViewModels;
using GenericBaseMVC.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Controllers;

[Authorize]
public class ChatController : Controller
{
    public IHubContext<MessageHub> _hub { get; set; }

    public ChatController(IHubContext<MessageHub> hub)
    {      
        _hub = hub;
    }

    public async Task<IActionResult> Index()
    {
        var model = new ChatViewModel();
        var userEmail = User.Identity.Name ?? "none";

        var Users = await new CustomerService().Get(userEmail);
        var Recivers = await new CustomerService().Get();
        var user = Users.FirstOrDefault();
        var reciever = Recivers.FirstOrDefault();
        var allMessagesDto = await DirectMessageService.Get("none", user.ModelGUID);
        //await ChatService.Get(userEmail);

        foreach (var message in allMessagesDto)
        {
            model.AllMessages.Add(new DirectMessageViewModel()
            {
                Message = message.Message,
                SenderGUID = message.SenderGuid,
                ReaderGUID = message.RecieverGuid,
                CreationDateTime = message.CreatedDateTime,
                CreatorGUID = message.CreatorGuid,
            });
        }

        model.ChatHead = new ChatHeaderViewModel()
        {
            RecieverName = reciever.CustomerName,
            ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
            ChatId = "2",

        };

        model.NewMessage = new SendDirectMessageViewModel()
        {
            SenderGuid = user.ModelGUID,
            SenderId = user.Id,
            RecieverGuid = reciever.ModelGuid,
            RecieverId = reciever.Id,
            Message = "",
        };

        return View("AllMyChats", model);
    }

    public async Task<IActionResult> Get()
    {
        var model = new ChatViewModel();
        var userEmail = User.Identity.Name;
        
        await new CustomerService().Get(userEmail);
        await DirectMessageService.Get(userEmail);
        await ChatService.Get(userEmail);

        return View("AllMyChats",model);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        var model = new ChatViewModel();
        var userEmail = User.Identity.Name ?? "";
        
        await DirectMessageService.Get(id);
        await ChatService.Get(id);

        

        return View("AllMyChats",model);
    }

    [HttpGet]
    public async Task<IActionResult> SendDirectMessage(string id)
    {
        var model = new ChatViewModel();
        var userEmail = User.Identity.Name ?? "none";
        var userService = new CustomerService();
        var Users = await userService.Get(userEmail);
        var Recivers = await userService.Get(id);
        var user = Users.FirstOrDefault();
        var reciever = Recivers.FirstOrDefault();
        //var allMessagesDto = await DirectMessageService.Get(id, user.ModelGUID);
        var allMessagesDto = await DirectMessageService.Get(user.ModelGUID);

        var users = new List<string>();
        users.AddRange(allMessagesDto.Where(m =>  m.RecieverGuid == user.ModelGUID).DistinctBy(k=>k.SenderGuid).Select(t=>t.SenderGuid).ToList());
        users.AddRange(allMessagesDto.Where(m =>  m.SenderGuid == user.ModelGUID).DistinctBy(k=>k.RecieverGuid).Select(t => t.RecieverGuid).ToList());
        users = users.Distinct().ToList();
        //await ChatService.Get(userEmail);
        allMessagesDto = allMessagesDto.Where(m => (m.SenderGuid == id && m.RecieverGuid == user.ModelGUID) || (m.SenderGuid == user.ModelGUID && m.RecieverGuid == id)).ToList();
        var OtherChats = new List<ChatHeaderViewModel>();
        foreach (var userid in users)
        {
            //create api endpoint to take list of string to return list of equal size back instead of looping
            var useridProfile = (await userService.Get(userid)).FirstOrDefault();
            model.OtherChatHeads.Add(
                new ChatHeaderViewModel() { 
                RecieverName = useridProfile.CustomerName,
                ChatId = useridProfile.ModelGUID,
                ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png", 
                CreatorId = useridProfile.ModelGUID,
                //Id = useridProfile.ModelGUID
                }
                );
        }
        model.ChatHead = new ChatHeaderViewModel()
        {
            RecieverName = user.UserName,
            ChatId = user.ModelGUID,
            ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
            CreatorId = user.ModelGUID,
            //Id = useridProfile.ModelGUID
        };

        foreach (var message in allMessagesDto)
        {
            model.AllMessages.Add(new DirectMessageViewModel()
            {
                Message = message.Message,
                SenderGUID = message.SenderGuid,
                ReaderGUID = message.RecieverGuid,
                CreationDateTime = message.CreatedDateTime,
                CreatorGUID = message.CreatorGuid,
                MyGuid = user.ModelGUID
            });
        }

        model.ChatHead = new ChatHeaderViewModel() { 
        RecieverName = reciever.CustomerName,
        ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
        ChatId = "1",
       
        };

        model.NewMessage = new SendDirectMessageViewModel() { 
        SenderGuid = user.ModelGUID,
        SenderId = user.Id,
        RecieverGuid = reciever.ModelGUID,
        RecieverId = reciever.Id,
        Message = "",
        };

        return View("AllMyChats",model);
    }

    [HttpPost]
    public async Task<IActionResult> SendDirectMessage(SendDirectMessageViewModel model)
    {
        var userEmail = User.Identity.Name ?? "none";

        var Users = await new CustomerService().Get(userEmail);
        var user = Users.FirstOrDefault();
        await DirectMessageService.Post(model);
        //await ChatService.Create(model);
        var code = 102;
        if (user.ModelGUID == model.SenderGuid)
        {
            code = 101;
        }

        var SRMessage = new SignalRMessage()
        {
            Message = model.Message,
            SenderId = model.SenderGuid,
            RecieverId = model.RecieverGuid,
            Attachment = model.Attachment,
            Code = code
        };

        await SendAMessage(SRMessage);

        return RedirectToAction(actionName:"SendDirectMessage",routeValues: model.RecieverGuid);
    }

    public async Task SendAMessage(SignalRMessage Message)
    {
        await _hub.Clients.All.SendAsync("RecieveMessage", Message);
    }

}
