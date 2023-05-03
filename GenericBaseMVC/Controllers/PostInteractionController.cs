using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    public class PostInteractionController : Controller
    {
        public IMapper Mapper { get; }
        public MeetUpService _meetupService { get; set; }
        public PostInteractionService _postInteractionService { get; set; }

        public PostInteractionController(IMapper mapper)
        {
            Mapper = mapper;
            _postInteractionService = new PostInteractionService();
        }


        public async Task<IActionResult> Like(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();


            var newLike = new PostInteractionViewModel()
            {
                PostGuid = id,
                Type = 2,
                Status = 1,
                SenderName = currentCustomer.CustomerName,
                SenderGuid = currentCustomer.ModelGuid,
                SentDateTime = DateTime.Now.ToString()
            };

            var dto = Mapper.Map<CreatePostInteractionDto>(newLike);

            await _postInteractionService.Create(dto);

            var points = new PointsDto()
            {
                AccountGuid = currentCustomer.AccountGuid,
                Description = "Liked Post",
                Type = 2,
                SenderType = 2,
                UserGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                Amount = 5,
                CreatedDateTime = DateTime.Now.ToString(),
            };

            await new PointsService().Post(points);

            return RedirectToAction("Feed", "Post");
        }

        public async Task<IActionResult> Comment(PostInteractionViewModel model)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();


            var newComment = new PostInteractionDto()
            {
                PostGuid = model.PostGuid,
                UserGuid = currentCustomer.ModelGuid,
                Type = 3,
                Status = 1,
                Body = model.Body,
                SenderName = currentCustomer.CustomerName,
                SenderGuid = currentCustomer.ModelGuid,
                SentDateTime = DateTime.Now.ToString()
            };
            var dto = Mapper.Map<CreatePostInteractionDto>(newComment);

            await _postInteractionService.Create(dto);

            var points = new PointsDto()
            {
                AccountGuid = currentCustomer.AccountGuid,
                Description = "Commented On Post",
                Type = 2,
                SenderType = 2,
                UserGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                Amount = 15,
                CreatedDateTime = DateTime.Now.ToString(),
            };

            await new PointsService().Post(points);

            return RedirectToAction("Feed","Post");
        }



        public async Task<IActionResult> Get()
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();


            return View();
        }
        public async Task<IActionResult> Get(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();


            return View();
        }
        public async Task<IActionResult> Post()
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();


            return View();
        }
        public async Task<IActionResult> Put()
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            return View();
        }
    }
}
