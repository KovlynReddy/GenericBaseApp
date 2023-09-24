using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/Relationship")]
    [ApiController]
    public class RelationshipController : Controller
    {
        public IRelationship _relationDb { get; }
        public IMapper Mapper { get; }

        public RelationshipController(IRelationship relationDb,IMapper mapper)
        {
            _relationDb = relationDb;
            Mapper = mapper;
        }


        [Route("~/api/Relationship")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _relationDb.Get();

            return Ok(response);

        }        
        
        [Route("~/api/Relationship/{Id}")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var response = await _relationDb.Get(Id);

            return Ok(response);

        }

        [Route("~/api/Relationship")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateRelationshipDto dto)
        {
            var dtoModel = Mapper.Map<RelationshipDto>(dto);
            var response = await _relationDb.Post(dtoModel);

            return Ok();

        }        
        
        [Route("~/api/Relationship")]
        [HttpPut]
        public async Task<IActionResult> Put(RelationshipDto dto)
        {
            var response = _relationDb.Put(dto);

            return Ok();

        }
    }
}
