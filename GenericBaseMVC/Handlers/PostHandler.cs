using GenericBaseMVC.Services;

namespace GenericBaseMVC.Handlers
{
    public static class PostHandler
    {

        public static async Task<List<PostViewModel>> GetAllPosts(string currentCustomer)
        {

            var _customerService = new CustomerService();
            var currentCustomerModel = (await _customerService.Get(currentCustomer)).FirstOrDefault();
            var _PostService = new PostService();
            var _postInteractionService = new PostInteractionService();
            var model = new FeedViewModel();
            var AllPostsDTO = await _PostService.GetAll(currentCustomer);
            var AllPostVM = new List<PostViewModel>();
            var AllCustomers = await _customerService.Get();

            foreach (var post in AllPostsDTO)
            {
                var postInteractions = await _postInteractionService.Get(post.ModelGuid);
                if (postInteractions.Where(m=>m.Type==5 && m.PostGuid == post.ModelGuid && m.SenderGuid == currentCustomer).ToList().Count == 0 )
                {
                    var viewPost = new CreatePostInteractionDto()
                    {
                        PostGuid = post.ModelGuid,
                        UserGuid= currentCustomer,
                        SenderName = currentCustomerModel.CustomerName,
                        ModelGuid = Guid.NewGuid().ToString(),
                        Type = 5,
                        Status = 1,
                        SenderGuid = currentCustomer,
                        SentDateTime = DateTime.Now.ToString()
                    };

                    await _postInteractionService.Create(viewPost);
                }

                PostFooterViewModel footer = new PostFooterViewModel();
                if (postInteractions != null)
                {
                    footer.NumLikes = postInteractions.Where(m => m.Type == 2).Count();
                    footer.NumComments = postInteractions.Where(m => m.Type == 3).Count();
                    footer.LastComments = postInteractions.Where(m => m.Type == 3).LastOrDefault() != null ? postInteractions.Where(m => m.Type == 3).LastOrDefault().Body : "Enter A Comment";
                }
                else
                {
                    footer.NumLikes = 0;
                    footer.NumComments = 0;
                    footer.LastComments = "Be The First To Comment";
                }

                if (postInteractions.Where(m => m.Type == 3).FirstOrDefault() != null)
                {
                    foreach (var comment in postInteractions.Where(m => m.Type == 3).ToList())
                    {
                        var email = comment.SenderGuid;
                        var commentSender = (await _customerService.Get(email)).FirstOrDefault();

                        footer.comments.Add(new CommentViewModel()
                        {
                            SenderGuid = commentSender.ModelGuid,
                            SentDateTime = comment.SentDateTime,
                            Comment = comment.Body,
                            CommentGuid = comment.ModelGuid,
                            SenderProfilePicture = commentSender.ProfileImagePath,
                            SenderName = commentSender.CustomerName
                        });
                    }
                }

                //footer.comments = ;

                footer.postInteraction = new PostInteractionViewModel()
                {
                    SenderGuid = currentCustomer,
                    PostGuid = post.ModelGuid,

                };

                var SenderDetails = AllCustomers.FirstOrDefault(m=>m.ModelGuid==post.SenderGuid);
                var SenderVM = new PostHeaderViewModel() { SenderDetails = new ProfileHeaderViewModel() { 
                
                CustomerName = SenderDetails.CustomerName,
                ProfileImagePath = SenderDetails.ProfileImagePath,
                CustomerEmail = SenderDetails.CustomerEmail,
                UserId = SenderDetails.UserGuid,
                SelectedTheme = SenderDetails.SelectedTheme
                } };

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
                    PostGuid = post.ModelGuid,
                    postHeader = SenderVM
                };
                newEntity.AttatchmentPath = newEntity.AttatchmentPath;//.Split("root\\")[1];

                AllPostVM.Add(newEntity);

            }

            return AllPostVM;
        }

    }
}
