﻿using GenericAppDLL.Models.ViewModels;
using GenericBaseMVC.Constants;
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
        var model = await CreateChatViewModel(string.Empty);

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
        var model = await CreateChatViewModel(id);

        return View("AllMyChats",model);
    }

    public async Task<ChatViewModel> CreateChatViewModel(string id) {
        var model = new ChatViewModel();
        model.emojis = new Emojis().emojis;
        var userEmail = User.Identity.Name ?? "none";
        var userService = new CustomerService();
        var Users = await userService.Get(userEmail);
        var user = Users.FirstOrDefault();
        var Recievers = new List<CustomerDto>();
        var allMessagesDto = await DirectMessageService.Get(user.ModelGuid);
        var reciever = new CustomerDto();
        if (!string.IsNullOrEmpty(id)){ 
            Recievers = await userService.Get(id);
            reciever = Recievers.FirstOrDefault();
        }
        else { 
            Recievers = await userService.Get();
            var firstMessageId = allMessagesDto.FirstOrDefault(m => m.SenderGuid != user.ModelGuid).SenderGuid;
            if (string.IsNullOrEmpty(firstMessageId))
            {
                firstMessageId = allMessagesDto.FirstOrDefault(m => m.RecieverGuid != user.ModelGuid).RecieverGuid;
            }
            reciever = Recievers.FirstOrDefault(m => m.ModelGuid == firstMessageId);
        } 
        
        
        //var allMessagesDto = await DirectMessageService.Get(id, user.ModelGUID);
        var users = new List<string>();
        users.AddRange(allMessagesDto.Where(m => m.RecieverGuid == user.ModelGuid).DistinctBy(k => k.SenderGuid).Select(t => t.SenderGuid).ToList());
        users.AddRange(allMessagesDto.Where(m => m.SenderGuid == user.ModelGuid).DistinctBy(k => k.RecieverGuid).Select(t => t.RecieverGuid).ToList());
        users = users.Distinct().ToList();
        //await ChatService.Get(userEmail);
        var CurrentChatMessages = allMessagesDto.Where(m => (m.SenderGuid == reciever.ModelGuid && m.RecieverGuid == user.ModelGuid) || (m.SenderGuid == user.ModelGuid && m.RecieverGuid == reciever.ModelGuid)).ToList();
        var OtherChats = new List<ChatHeaderViewModel>();
        foreach (var userid in users)
        {
            var LastMessage = allMessagesDto.Where(m => m.SenderGuid == userid || m.RecieverGuid == userid).OrderBy(k => k.CreatedDateTime).LastOrDefault();
            //create api endpoint to take list of string to return list of equal size back instead of looping
            var useridProfile = (await userService.Get(userid)).FirstOrDefault();
            model.OtherChatHeads.Add(
                new ChatHeaderViewModel()
                {
                    RecieverName = useridProfile.CustomerName,
                    ChatId = useridProfile.ModelGuid,
                    ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
                    CreatorId = useridProfile.ModelGuid,
                    LastMessage = LastMessage.Message,
                    LastMessageSent = LastMessage.CreatedDateTime.ToString(),
                    //Id = useridProfile.ModelGUID
                }
                );
        }

        model.ChatHead = new ChatHeaderViewModel()
        {
            RecieverName = user.CustomerName,
            ChatId = user.ModelGuid,
            ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
            CreatorId = user.ModelGuid,
            //Id = useridProfile.ModelGUID
        };

        foreach (var message in CurrentChatMessages)
        {
            model.AllMessages.Add(new DirectMessageViewModel()
            {
                Message = message.Message,
                SenderGUID = message.SenderGuid,
                ReaderGUID = message.RecieverGuid,
                CreationDateTime = message.CreatedDateTime,
                CreatorGUID = message.CreatorGuid,
                MyGuid = user.ModelGuid

            });
        }

        model.ChatHead = new ChatHeaderViewModel()
        {
            RecieverName = reciever.CustomerName,
            ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
            ChatId = "1",

        };

        model.NewMessage = new SendDirectMessageViewModel()
        {
            SenderGuid = user.ModelGuid,
            SenderId = user.Id,
            RecieverGuid = reciever.ModelGuid,
            RecieverId = reciever.Id,
            Message = "",
        };

        return model;

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
        if (user.ModelGuid == model.SenderGuid)
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
