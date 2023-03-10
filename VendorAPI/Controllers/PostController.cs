using Microsoft.AspNetCore.Mvc;

namespace VendorAPI.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly VendorContext _context;

        public PostController(VendorContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Feed()
        {
            return View(await _context.Customers.ToListAsync());
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

        [HttpGet]
        [Route("~/api/Post/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Posts.ToListAsync();

            var response = new List<PostDto>();

            foreach (var model in result)
            {

                PostDto Dto = new PostDto
                {
                    SenderGuid = model.SenderGuid,
                    AttatchmentPath = model.AttatchmentPath,
                    Caption = model.Caption,
                    Feature = model.Feature,
                    GroupGuid = model.GroupGuid,
                    Interactions = model.Interactions,
                    Message = model.Message,
                    RecieverGuid = model.RecieverGuid,
                };

                response.Add(Dto);

            }

            return Ok(response);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        //[AllowAnonymous]
        [Route("~/api/Post/CreateDto")]
        [HttpPost]
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
            };



            return Ok(dto);
        }


        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
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
        [HttpPost, ActionName("Delete")]
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
