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

    [HttpGet]
    [Route("~/api/Customers/Index")]
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
                CreatedDateTimeString = customer.CreatedDateTime,
                SelectedTheme = customer.SelectedTheme,
                ProfileImagePath = !(string.IsNullOrEmpty(customer.ProfileImagePath) || customer.ProfileImagePath == "~/profileimage.png" || customer.ProfileImagePath == "ProfileImages/ProfileImage.png") ? customer.ProfileImagePath : @"ProfileImages/ProfileImage.png",
                AccountGuid = customer.AccountGuid,
                LastTotal = customer.LastTotal
                //ProfileImagePath = !(string.IsNullOrEmpty(customer.ProfileImagePath) || customer.ProfileImagePath == "~/profileimage.png" || customer.ProfileImagePath == "ProfileImages/ProfileImage.png") ? customer.ProfileImagePath.Split("root\\")[1] : @"ProfileImages/ProfileImage.png"
            };

            response.Add(CustomerDto);
        }

        response.Reverse();

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
                CreatedDateTimeString = customer.CreatedDateTime,
                ProfileImagePath = !(string.IsNullOrEmpty(customer.ProfileImagePath) || customer.ProfileImagePath == "~/profileimage.png" || customer.ProfileImagePath == "ProfileImages/ProfileImage.png") ? customer.ProfileImagePath: @"ProfileImages/ProfileImage.png" ,
                AccountGuid = customer.AccountGuid,
                LastTotal = customer.LastTotal
                //ProfileImagePath = !(string.IsNullOrEmpty(customer.ProfileImagePath) || customer.ProfileImagePath == "~/profileimage.png" || customer.ProfileImagePath == "ProfileImages/ProfileImage.png") ? customer.ProfileImagePath.Split("root\\")[1]: @"ProfileImages/ProfileImage.png" 
            };
            response.Add(CustomerDto);
        }

        response.Reverse();

        return Ok(response);
    }

    [HttpPut]
    [Route("~/api/Customers/UpdateTheme")]
    public async Task<IActionResult> UpdateTheme(CustomerDto customer)
    {
        var entity = _context.Customers.FirstOrDefault(m => m.ModelGUID == customer.ModelGuid || m.Email == customer.CustomerEmail);
        //var rawResult = _context.Update(entity);
        entity.SelectedTheme = customer.SelectedTheme;
        entity.ProfileImagePath = customer.ProfileImagePath;
        var SelectedTheme = _context.Entry(entity).Property("SelectedTheme").IsModified;
        var UpdatedProfileImage = _context.Entry(entity).Property("ProfileImagePath").IsModified;
        _context.SaveChanges();

        return Ok(customer);
    }

    [Route("~/api/Customers/CreateDto")]
    [HttpPost]
    public async Task<IActionResult> CreateDto(CreateCustomerDto Vendor)
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
            CustomerAddress = "",
            ProfileImagePath = Vendor.ProfileImagePath.Split("root\\")[1]

        };
        _context.Add(newVendor);
        await _context.SaveChangesAsync();
        return Ok(newVendor);
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.Id == id);
    }
}
