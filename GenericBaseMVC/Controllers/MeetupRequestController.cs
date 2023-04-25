using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    public class MeetupRequestController : Controller
    {
        public IMapper Mapper { get; }
        public MeetUpService _meetupService { get; set; }
        public MeetupRequestService _meetupRequestService { get; set; }

        public MeetupRequestController(IMapper mapper)
        {
            Mapper = mapper;
            _meetupService = new MeetUpService();
            _meetupRequestService = new MeetupRequestService();
        }
        public async Task<IActionResult> Get()
        {
            var model = new ViewListMeetupRequests();
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            var results = await _meetupRequestService.Get();
            model.settings.SelectedTheme = currentCustomer.SelectedTheme;

            model.meetups = Mapper.Map<List<MeetupViewRequestModel>>(results.ToList());

            return View("ListView",model);
        }        
        
        public async Task<IActionResult> Accept(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            var dto = new CreateMeetupRequestDto() { 
            SenderGuid = currentCustomer.ModelGuid,
            ModelGuid = Guid.NewGuid().ToString(),
            MeetupGuid = id,
            SenderName = currentCustomer.CustomerName,
            SentDateTime = DateTime.Now.ToString(),
            Status = 1,
            Description = "",
            Caption = "",
            CreatedDateTime = DateTime.Now,
            };

            await _meetupRequestService.Post(dto);

            return View();
        }       
        
        public async Task<IActionResult> Deny(string id)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            var dto = new CreateMeetupRequestDto()
            {
                SenderGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                MeetupGuid = id,
                SenderName = currentCustomer.CustomerName,
                SentDateTime = DateTime.Now.ToString(),
                Status = 1,
                Description = "",
                Caption = "",
                CreatedDateTime = DateTime.Now,
            };

            await _meetupRequestService.Post(dto);


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
