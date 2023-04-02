using GenericAppDLL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
[Route("api/Chat")]
[ApiController]
public class ChatController : Controller
{
    public IDirectMessagesDB _DirectMessageDb { get; set; }
    public ChatController(IDirectMessagesDB directMessageDb)
    {
            _DirectMessageDb = directMessageDb;
    }
    // GET: ChatController

    [HttpGet]
    [Route("~/api/Chat/Get")]
    public ActionResult Get()
    {
        return Ok();
    }


    // GET: ChatController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    [HttpGet]
    [Route("~/api/Chat/GetAll")]
    public ActionResult GetAll()
    {
        var results = _DirectMessageDb.Get();

        var dtos = new List<DirectMessage>();
        if (results.ToList().Count > 0)
        {
            foreach (var item in results)
            {
                var entity = new DirectMessage()
                {
                    ChatName     = item.ChatName,
                    CreatedDateTime = item.CreatedDateTime,
                    CreatorGuid     = item.CreatorId,
                    Id              = item.Id
                };
                dtos.Add(entity);
            }
        }


        return Ok(results);
    }


    // GET: ChatController/Create
    [HttpPost]
    [Route("~/api/Chat/Create")]
    public ActionResult Create(CreateDirectMessageDto model)
    {
        //_DirectMessageDb.Post(model);

        return Ok();
    }

    // POST: ChatController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ChatController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ChatController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ChatController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ChatController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
}
