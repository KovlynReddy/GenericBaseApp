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
    public IDirectMessagesDB _DB { get; set; }
    public DirectMessageController(IDirectMessagesDB DMDb)
    {
            _DB = DMDb;
    }
        // GET: DirectMessageController

        [HttpPut]
        [Route("~/api/Read/DirectMessage")]
        public async Task<IActionResult> Put(ReadMessageDto messageId) {

            await _DB.Put(messageId.MessageGuid);

            return Ok();
        }

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
                        RecieverGuid = item.RecieverGuid,
                        Read = item.Read,
                        ModelGUID = item.ModelGuid
                    };
                    dtos.Add(entity);
                }
            }


            return Ok(results);
        }    
        
    [HttpGet]
        [Route("~/api/DirectMessage/{id}/{email}")]
        public async Task<IActionResult> Get(string id,string email)
    {
            var results = await _DB.Get(id,email);

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
                        RecieverGuid = item.RecieverGuid,
                        Read = item.Read,
                        ModelGUID = item.ModelGuid
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
    [Route("~/api/DirectMessage/Create")]
    public async Task<ActionResult> Create(DirectMessageDto model)
    {
        await _DB.Post(model);

        return Ok();
    }
}
}
