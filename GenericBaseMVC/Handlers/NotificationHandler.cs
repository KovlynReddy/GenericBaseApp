﻿using GenericBaseMVC.Services;

namespace GenericBaseMVC.Handlers
{
    public static class NotificationHandler
    {
        public static async Task<int> GetNotifications(string email) {
            int notifications = 0;
            var _customerService = new CustomerService();
            var _postInteractionService = new PostInteractionService();
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var _PostService = new PostService();
            // meetups near me which did not expire
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
                }
            }

            return notifications;

        }
    }
}