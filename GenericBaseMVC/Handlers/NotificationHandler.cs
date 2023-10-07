using GenericAppDLL.Models.DomainModel;
using GenericBaseMVC.Services;
using Microsoft.Extensions.Hosting;

namespace GenericBaseMVC.Handlers
{
    public static class NotificationHandler
    {
        public static async Task<NotificationsViewModel> GetNotifications(string email) {
            int notifications = 0;
            var _meetupRequestService = new MeetupRequestService();
            var _meetupService = new MeetUpService();
            var _customerService = new CustomerService();
            var _postInteractionService = new PostInteractionService();
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var _PostService = new PostService();
            var model = new NotificationsViewModel();


            // meetups near me which did not expire


            // meetup requests that wore responded 

            var customers = await _customerService.Get();
            var myRequests = await _meetupRequestService.Get(currentCustomer.ModelGuid);
            var meetups = await _meetupService.Get();

            foreach (var request in myRequests.Where(m=>m.SenderGuid == currentCustomer.ModelGuid))
            {
                var meetupDetails = meetups.Single(m => m.ModelGuid == request.MeetupGuid);
                var senderDetails = customers.Single(m => m.ModelGuid == meetupDetails.SenderGuid);

                if (request.Status == 1)
                {
                    model.notifications.Add(new NotificationViewModel()
                    {
                        DateTime = request.CreatedDateTimeString,
                        Heading = "Pending Request",
                        Body = $"{senderDetails.CustomerName} has not responded to your request to MEETUP , please check in later",
                        Description = request.Caption,
                        Link = "",
                        Type = 1
                    });
                } else if (request.Status == 2) {
                    model.notifications.Add(new NotificationViewModel()
                    {
                        DateTime = request.CreatedDateTimeString,
                        Heading = "Your Request was Accepted" ,
                        Body = $"{senderDetails.CustomerName} has accepted your request to MEETUP , please click the link or head to the following location {meetupDetails.Lat}  {meetupDetails.lon}",
                        Description = request.Caption,
                        Link = $"",
                        Type = 1
                    });
                }else if (request.Status == 3) {
                    model.notifications.Add(new NotificationViewModel()
                    {
                        DateTime = request.CreatedDateTimeString,
                        Heading = "Your Request Denied",
                        Body = $"{senderDetails.CustomerName} has denied your request to MEETUP , please check suggested meetups for more",
                        Description = request.Caption,
                        Link = "",
                        Type = 1
                    });
                }
            }

            foreach (var request in myRequests.Where(m => m.ReaderGuid == currentCustomer.ModelGuid))
            {
                if (request.Status == 1)
                {
                    var meetupDetails = meetups.Single(m=>m.ModelGuid == request.MeetupGuid);
                    var senderDetails = customers.Single(m=>m.ModelGuid == meetupDetails.SenderGuid);
                    model.notifications.Add(new NotificationViewModel()
                    {
                        DateTime = request.CreatedDateTimeString,
                        Body = $"{senderDetails.CustomerName} has sent you a request to MEETUP , please check the meetup requests page under meetup",
                        Description = "New Meetup Request Recieved",
                        Heading = request.Caption,
                        Link = $"",
                        Type = 1
                    });
                }
            }


            // friends posts not seen

            //var AllPostVM = await PostHandler.GetAllPosts(currentCustomer.ModelGuid);

            var AllPostsDTO = await _PostService.GetAll(currentCustomer.ModelGuid);
            var AllPostVM = new List<PostViewModel>();

            foreach (var post in AllPostsDTO)
            {
                var postInteractions = await _postInteractionService.Get(post.ModelGuid);

                if (postInteractions.Where(m => m.Type == 5 && m.PostGuid == post.ModelGuid && m.SenderGuid == currentCustomer.ModelGuid).ToList().Count == 0)
                {
                // add notification ----------------------------------------------------
                notifications++;
                    model.notifications.Add(new NotificationViewModel() { 
                    DateTime = post.CreatedDateTimeString ,
                    Description = "New Post",
                    Heading = post.Caption,
                    Link ="" ,
                    Type = 1
                    });
                }
            }
            

            // messages read


            var allMessagesDto = await DirectMessageService.Get(currentCustomer.ModelGuid);

            foreach (var message in allMessagesDto)
            {
                if (message.Read == 0 && message.RecieverGuid == currentCustomer.ModelGuid)
                {
                    notifications++;
                    // add notification ----------------------------------------------------
                    model.notifications.Add(new NotificationViewModel()
                    {
                        DateTime = message.CreatedDateTimeString,
                        Description = "New Message",
                        Heading = message.Message,
                        Link = "",
                        Type = 2
                    });
                }
            }

            model.NumNotifcations = notifications;

            return model;

        }
    }
}
