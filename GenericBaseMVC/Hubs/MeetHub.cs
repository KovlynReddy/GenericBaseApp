using Microsoft.AspNetCore.SignalR;

namespace GenericBaseMVC.Hubs
{
    public class MeetHub : Hub
    {
        public Task SendRequest(SignalRMeet message)
        {

            return Clients.All.SendAsync(method: "MeetupRequestRecieved", message);
        }
    }
}
