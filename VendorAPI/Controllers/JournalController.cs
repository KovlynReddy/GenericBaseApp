using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/Journal")]
    [ApiController]
    public class JournalController : Controller
    {
        public IJournalDB JournalDB { get; }
        public IMapper Mapper { get; }

        public JournalController(IJournalDB journalDb, IMapper mapper)
        {
            JournalDB = journalDb;
            Mapper = mapper;
        }


        [HttpGet]
        [Route("~/api/Journal")]
        public async Task<IActionResult> Get()
        {
            var result = await JournalDB.Get();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Route("~/api/Journal/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await JournalDB.Get(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("~/api/Journal")]
        public async Task<IActionResult> Post(JournalEntryDto newDto)
        {
            //var dto = Mapper.Map<JournalEntryDto>(newDto);

            var result = await JournalDB.Post(newDto);

            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/Journal")]
        public async Task<IActionResult> Put(JournalEntryDto Dto)
        {
            var result = await JournalDB.Put(Dto);

            return Ok();
        }
    }
}
