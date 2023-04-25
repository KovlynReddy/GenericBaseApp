using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;
using VendorAPI.Data.Repository;

namespace VendorAPI.Controllers
{
    [Route("api/PostInteraction")]
    [ApiController]
    public class PostInteractionController : Controller
    {
        public IPostInteractionDB PostInteractionDB { get; }
        public IMapper Mapper { get; }

        public PostInteractionController(IPostInteractionDB postInteractionDB, IMapper mapper)
        {
            PostInteractionDB = postInteractionDB;
            Mapper = mapper;
        }


        [HttpGet]
        [Route("~/api/PostInteraction")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("~/api/PostInteraction/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("~/api/PostInteraction")]
        public async Task<IActionResult> Post(CreatePostInteractionDto newDto)
        {
            var dto = Mapper.Map<PostInteractionDto>(newDto);

            var result = await PostInteractionDB.Post(dto);

            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/PostInteraction")]
        public async Task<IActionResult> Put(PostInteractionDto Dto)
        {
            var result = await PostInteractionDB.Put(Dto);

            return Ok();
        }
    }
}
