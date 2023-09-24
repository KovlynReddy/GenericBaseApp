using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;
using VendorAPI.Data.Repository;

namespace VendorAPI.Controllers
{
    [Route("api/Points")]
    [ApiController]
    [AllowAnonymous]
    public class PointsController : Controller
    {
        public IPointsDB _pointsDb { get; }
        public IMapper Mapper { get; }
        public ICustomer CustomerDb { get; }

        public PointsController(IPointsDB pointsDb, IMapper mapper , ICustomer customerDb)
        {
            _pointsDb = pointsDb;
            Mapper = mapper;
            CustomerDb = customerDb;
        }

        [HttpGet]
        [Route("~/api/Points")]
        public async Task<IActionResult> Get()
        {
            var result = await _pointsDb.Get();

            return Ok(result);
        }

        [HttpGet]
        [Route("~/api/Points/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _pointsDb.Get(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("~/api/Points")]
        public async Task<IActionResult> Post(PointsDto newDto)
        {
            var owner = (await CustomerDb.Get(newDto.UserGuid)).FirstOrDefault();
            //var dto = Mapper.Map<PointsDto>(newDto);
            var accountId = owner.AccountGuid;
            if (string.IsNullOrEmpty(owner.AccountGuid))
            {
                accountId = Guid.NewGuid().ToString();
                owner.AccountGuid = accountId;
                await CustomerDb.Put(owner);
            }
            newDto.AccountGuid = accountId;


            var result = await _pointsDb.Post(newDto);

            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/Points")]
        public async Task<IActionResult> Put(PointsDto Dto)
        {
            var result = await _pointsDb.Put(Dto);

            return Ok();
        }

    }
}
