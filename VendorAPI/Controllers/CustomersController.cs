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

    [HttpGet]
    [Route("~/api/Customers/{email}/{state}")]
    public async Task<IActionResult> Get(string email,int state)
    {


        return Ok();
    }

    [HttpGet]
    [Route("~/api/Customers/{email}")]
    public async Task<IActionResult> Get(string email)
    {
        var result = await _context.Customers.Where(m=>m.ModelGUID == email || m.CustomerEmail == email || m.Email == email || m.UserId == email || m.Id.ToString() == email).ToListAsync();

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
    
    [HttpGet]
    [Route("~/api/Customers")]
    public async Task<IActionResult> Get()
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
    [HttpPut]
    [Route("~/api/Customers/UpdateTheme")]
    public async Task<IActionResult> UpdateTheme(CustomerDto customer)
    {
        var entity = _context.Customers.FirstOrDefault(m => m.ModelGUID == customer.ModelGuid || m.Email == customer.CustomerEmail);
        //var rawResult = _context.Update(entity);
        entity.SelectedTheme = customer.SelectedTheme;
        var IsPaid = _context.Entry(entity).Property("SelectedTheme").IsModified;
        _context.SaveChanges();

        return View(customer);
    }


    //[AllowAnonymous]
    [Route("~/api/Customers/CreateDto")]
    [HttpPost]
    public async Task<ActionResult<CreateCustomerDto>> CreateDto(CreateCustomerDto Vendor)
    {
        Customer newVendor = new Customer
        {
            CustomerEmail = Vendor.CustomerEmail,//
            CustomerName = Vendor.CustomerName,//
            ModelGUID = Guid.NewGuid().ToString(),
            UserName = Guid.NewGuid().ToString(),
            Email = Vendor.CustomerEmail, 
            UserId = Guid.NewGuid().ToString(),
            CreatorId = Guid.NewGuid().ToString(),
            CompletedDateTime = DateTime.Now.ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            CustomerAddress = ""
        };
        _context.Add(newVendor);
        await _context.SaveChangesAsync();
        return Ok(newVendor);
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
