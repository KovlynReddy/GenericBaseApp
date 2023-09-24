using AutoMapper;
using GenericAppDLL.Models.DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;
        private readonly IRelationship relationDb;

        public PostController(VendorContext context, IMapper mapper, IRelationship relationDb)
        {
            _context = context;
            this.mapper = mapper;
            this.relationDb = relationDb;
        }

        // GET: Customers
        public async Task<IActionResult> Feed()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("Get/{id}")]
        [Route("~/api/Post/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var entities = await _context.Posts.Where(m => m.SenderGuid == id || m.ModelGUID == id).ToListAsync();
            var response = new List<PostDto>();

            foreach (var model in entities)
            {

                PostDto Dto = new PostDto
                {
                    SenderGuid = model.SenderGuid,
                    AttatchmentPath = model.AttatchmentPath.Split("root\\")[1],
                    Caption = model.Caption,
                    Feature = model.Feature,
                    GroupGuid = model.GroupGuid,
                    Interactions = model.Interactions,
                    Message = model.Message,
                    RecieverGuid = model.RecieverGuid,
                    ModelGuid = model.ModelGUID,
                };

                response.Add(Dto);

            }
            //var dtos = mapper.Map<List<PostDto>>(entities);

            return Ok(response);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpGet("GetAll")]
        [Route("~/api/Post/GetAll/{currentCustomer}")]
        public async Task<IActionResult> GetAll(string currentCustomer)
         {
            var response = new List<PostDto>();
            var relationships = await relationDb.Get(currentCustomer);
            foreach (var relationship in relationships)
            {
                string otherid = "";
                if (currentCustomer == relationship.SenderId)
                {
                    otherid = relationship.RecieverId;
                }
                else
                {
                    otherid = relationship.SenderId;
                }
                var result = await _context.Posts.Where(m => m.SenderGuid == otherid).ToListAsync();


                foreach (var model in result)
                {

                    PostDto Dto = new PostDto
                    {
                        SenderGuid = model.SenderGuid,
                        AttatchmentPath = model.AttatchmentPath.Split("root\\")[1],
                        Caption = model.Caption,
                        Feature = model.Feature,
                        GroupGuid = model.GroupGuid,
                        Interactions = model.Interactions,
                        Message = model.Message,
                        RecieverGuid = model.RecieverGuid,
                        ModelGuid = model.ModelGUID
                    };

                    response.Add(Dto);
                }
            }

            response.Reverse();

            return Ok(response);
        }


        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        //[AllowAnonymous]
        [Route("~/api/Post/CreateDto")]
        [HttpPost("CreateDto")]
        public async Task<ActionResult<CreatePostDto>> CreateDto(CreatePostDto model)
        {
            Post newEntity = new Post
            {
                SenderGuid      = model.SenderGuid      ,
                AttatchmentPath = model.AttatchmentPath ,
                Caption         = model.Caption         ,
                Feature         = model.Feature         ,
                GroupGuid       = model.GroupGuid       ,
                Interactions    = model.Interactions    ,
                Message         = model.Message         ,
                RecieverGuid    = model.RecieverGuid    ,
                ModelGUID = Guid.NewGuid().ToString()
            };
            _context.Add(newEntity);
            await _context.SaveChangesAsync();

            PostDto dto = new PostDto
            {
                SenderGuid = newEntity.SenderGuid,
                AttatchmentPath = newEntity.AttatchmentPath,
                Caption = newEntity.Caption,
                Feature = newEntity.Feature,
                GroupGuid = newEntity.GroupGuid,
                Interactions = newEntity.Interactions,
                Message = newEntity.Message,
                RecieverGuid = newEntity.RecieverGuid,
                ModelGuid = newEntity.ModelGUID
            };
            // add address 

            return Ok(dto);
        }


        // GET: Customers/Delete/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpDelete("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }

}
