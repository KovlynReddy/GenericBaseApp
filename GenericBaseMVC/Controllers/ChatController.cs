﻿using GenericBaseMVC.Hubs;
using GenericBaseMVC.Services;
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
            ChatId = 2,

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

        var Users = await new CustomerService().Get(userEmail);
        var Recivers = await new CustomerService().Get(id);
        var user = Users.FirstOrDefault();
        var reciever = Recivers.FirstOrDefault();
        var allMessagesDto = await DirectMessageService.Get(id, user.ModelGUID);
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

        model.ChatHead = new ChatHeaderViewModel() { 
        RecieverName = reciever.CustomerName,
        ProfilePicturePath = "C:\\Users\\KovlynR\\Documents\\Projects\\GenericBaseApp\\GenericBaseMVC\\wwwroot\\ProfileImage.png",
        ChatId = 1,
       
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

        //await ChatService.Create(model);

        var SRMessage = new SignalRMessage()
        {
            Message = model.Message,
            UserId = model.SenderId,
            MeetingId = model.RecieverId
        };

        await SendAMessage(SRMessage);

        return RedirectToAction("AttendMeeting", model.RecieverId);
    }

    public async Task<IActionResult> SendAMessage(SignalRMessage Message)
    {
        await _hub.Clients.All.SendAsync("RecieveMessage", Message);
        return View();
    }

}
