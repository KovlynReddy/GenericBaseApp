using Microsoft.AspNetCore.Mvc;

namespace VendorAPI.Controllers
{
    [Route("api/PostInteraction")]
    [ApiController]
    public class PostInteractionController : Controller
    {
        [HttpGet]
        [Route("~/api/PostInteraction")]
        public async Task<IActionResult> Get()
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/PostInteraction/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/PostInteraction")]
        public async Task<IActionResult> Post(CreatePostInteractionDto newDto)
        {
            return View();
        }

        [HttpPut]
        [Route("~/api/PostInteraction")]
        public async Task<IActionResult> Put(PostInteractionDto newDto)
        {
            return View();
        }
    }
}
