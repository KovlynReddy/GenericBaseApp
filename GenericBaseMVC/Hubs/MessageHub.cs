using GenericAppDLL.Models.Dto;
using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Hubs;
public class MessageHub : Hub
{
    public Task SendMessage(SignalRMessage message) {

        return Clients.All.SendAsync(method:"RecieveMessage",message);
    }
}
