using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/MeetupRequest")]
    [ApiController]
    public class MeetupRequestController : Controller
    {
        public IMeetupRequestDB MeetupRequestDB { get; }
        public IMapper Mapper { get; }

        public MeetupRequestController(IMeetupRequestDB _meetupRequestDB,IMapper mapper)
        {
            MeetupRequestDB = _meetupRequestDB;
            Mapper = mapper;
        }


        [HttpGet]
        [Route("~/api/MeetupRequest")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("~/api/MeetupRequest/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("~/api/MeetupRequest")]
        public async Task<IActionResult> Post(CreateMeetupRequestDto newDto)
        {
            var dto = Mapper.Map<MeetupRequestDto>(newDto);

            var result = await MeetupRequestDB.Post(dto);

            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/MeetupRequest")]
        public async Task<IActionResult> Put(MeetupRequestDto Dto)
        {
            var result = await MeetupRequestDB.Put(Dto);

            return Ok();
        }

    }
}
