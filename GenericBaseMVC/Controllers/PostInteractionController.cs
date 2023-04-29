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
            return View();
        }
        public async Task<IActionResult> Comment(PostInteractionViewModel model)
        {
            var dto = Mapper.Map<CreatePostInteractionDto>(model);

            await _postInteractionService.Create(dto);

            return View();
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
