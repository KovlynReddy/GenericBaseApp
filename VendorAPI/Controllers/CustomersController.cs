using Microsoft.AspNetCore.Mvc;

namespace VendorAPI.Controllers;

[Route("api/Customers")]
[ApiController]
public class CustomersController : Controller
{
    private readonly VendorContext _context;

    public CustomersController(VendorContext context)
    {
        _context = context;
    }

    // GET: Customers
    public async Task<IActionResult> Index()
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
    [Route("~/api/Customers/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Customers.ToListAsync();

        var response = new List<CustomerDto>();

        foreach (var customer in result)
        {

            CustomerDto CustomerDto = new CustomerDto
            {
                CustomerEmail = customer.CustomerEmail,
                UserGuid = customer.ModelGUID, 
                CustomerName = customer.CustomerName, 
                ModelGuid = customer.ModelGUID,
                CustomerAddress = customer.CustomerAddress,
                CreatedDateTime = DateTime.Parse(customer.CreatedDateTime),
                CreatedDateTimeString = customer.CreatedDateTime
            };

            response.Add(CustomerDto);

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
    [Route("~/api/Customers/CreateDto")]
    [HttpPost]
    public async Task<ActionResult<CreateCustomerDto>> CreateDto(CreateCustomerDto barber)
    {
        Customer newBarber = new Customer
        {
            CustomerEmail = barber.CustomerEmail,//
            CustomerName = barber.CustomerName,//
            ModelGUID = Guid.NewGuid().ToString(),
            UserName = Guid.NewGuid().ToString(),
            Email = barber.CustomerEmail, 
            UserId = Guid.NewGuid().ToString(),
            CreatorId = Guid.NewGuid().ToString(),
            CompletedDateTime = DateTime.Now.ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            CustomerAddress = ""
        };
        _context.Add(newBarber);
        await _context.SaveChangesAsync();
        return Ok(newBarber);
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
