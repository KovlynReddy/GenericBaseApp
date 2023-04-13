using GenericAppDLL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
[Route("api/DirectMessage")]
[ApiController]
[AllowAnonymous]
public class DirectMessageController : Controller
{
    public IBase<DirectMessageDto> _DB { get; set; }
    public DirectMessageController(IBase<DirectMessageDto> DMDb)
    {
            _DB = DMDb;
    }
    // GET: DirectMessageController

    [HttpGet]
    [Route("~/api/DirectMessage/{Id}")]
    public async Task<IActionResult> Get(string Id)
    {
            var results = await _DB.Get(Id);

            var dtos = new List<DM>();
            if (results.ToList().Count > 0)
            {
                foreach (var item in results)
                {
                    var entity = new DM()
                    {
                        CreatedDateTime = item.CreatedDateTimeString,
                        CreatorId = item.CreatorGuid,
                        Id = item.Id,
                        Message = item.Message,
                        SenderGuid = item.SenderGuid,
                        RecieverGuid = item.RecieverGuid
                    };
                    dtos.Add(entity);
                }
            }


            return Ok(results);
        }    
        
    [HttpGet]
    [Route("~/api/DirectMessage/Chat/{Id}")]
    public async  Task<IActionResult> GetChats(string Id)
    {
            var results = await _DB.Get(Id);

            var dtos = new List<DM>();
            if (results.ToList().Count > 0)
            {
                foreach (var item in results)
                {
                    var entity = new DM()
                    {
                        CreatedDateTime = item.CreatedDateTimeString,
                        CreatorId = item.CreatorGuid,
                        Id = item.Id,
                        Message = item.Message,
                        SenderGuid = item.SenderGuid,
                        RecieverGuid = item.RecieverGuid
                    };
                    dtos.Add(entity);
                }
            }


            return Ok(results);
        }

    [HttpGet]
    [Route("~/api/DirectMessage")]
    public async Task<ActionResult> Get()
    {
        var results = await _DB.Get();

        var dtos = new List<DM>();
        if (results.ToList().Count > 0)
        {
            foreach (var item in results)
            {
                var entity = new DM() 
                {
                    CreatedDateTime = item.CreatedDateTimeString,
                    CreatorId       = item.CreatorGuid,
                    Id              = item.Id,
                    Message         = item.Message,
                    SenderGuid      = item.SenderGuid,
                    RecieverGuid    = item.RecieverGuid
                };
                dtos.Add(entity);
            }
        }


        return Ok(results);
    }


    // GET: DirectMessageController/Create
    [HttpPost]
    [Route("~/api/DirectMessage")]
    public async Task<ActionResult> Post([FromBody]DirectMessageDto model)
    {
        await _DB.Post(model);

        return Ok();
    }
}
}
