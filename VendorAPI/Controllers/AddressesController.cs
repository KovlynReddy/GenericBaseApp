namespace VendorAPI.Controllers;

[Route("api/Address")]
[ApiController]
public class AddressesController : Controller
{
    private readonly VendorContext _context;

    public AddressesController(VendorContext context)
    {
        _context = context;
    }


    [HttpPost]
    [Route("~/api/Address/LinkAddress")]
    public async Task<IActionResult> LinkAddress(LinkAddressDto link)
    {
        var address = _context.Addresses.FirstOrDefault(m=>m.ModelGUID == link.AddressGuid);

        var person = _context.Customers.FirstOrDefault(m => m.ModelGUID == link.UserGuid);
        if (person == null || person == new Customer())
        {
            var Vendor = _context.Vendors.FirstOrDefault(m => m.ModelGUID == link.UserGuid);
            Vendor.AddressGuid = link.AddressGuid;
            _context.Update(Vendor);
            _context.Entry(Vendor).State = EntityState.Modified;
            _context.SaveChanges();
        }
        else {

            person.CustomerAddress = link.AddressGuid;
            _context.Update(person);
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
        }

        address.UserGuid = link.UserGuid;

        _context.Update(address);
        _context.Entry(address).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(address);
    }

    [HttpGet]
    [Route("~/api/Address/Index")]
    public async Task<IActionResult> Index()
    {
        var response = ConvertToDto(await _context.Addresses.ToListAsync());

        return Ok(response);
    }

    [HttpGet]
    [Route("~/api/Address/GetAll")]
    public async Task<IActionResult> GetAll() {

        var response = ConvertToDto(await _context.Addresses.ToListAsync());

        return Ok(response);
    }

    [HttpGet]
    [Route("~/api/Address/GetUsersAddress")]
    public async Task<IActionResult> GetUsersAddress(string id) {
        var response = ConvertToDto(await _context.Addresses.Where(m=>m.CreatorId==id).ToListAsync());

        return Ok(response);
    }

    [HttpPost]
    [Route("~/api/Address/LinkUserToAddress")]
    public async Task<IActionResult> LinkUserToAddress(string userId , string addressId)
    {
        var address = ConvertToDto(await _context.Addresses.Where(m => m.ModelGUID == addressId).ToListAsync());

        var response = address.FirstOrDefault();
        response.UserGuid = userId;

        _context.Attach(response);
        _context.Update(response);
        _context.Entry(response).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(response);
    }

    [HttpGet]
    [Route("~/api/Address/Details/{id}")]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var address = await _context.Addresses
            .FirstOrDefaultAsync(m => m.Id == id);
        if (address == null)
        {
            return NotFound();
        }

        return View(address);
    }

    [AllowAnonymous]
    [Route("~/api/Address/CreateDto")]
    [HttpPost]
    public async Task<IActionResult> CreateDto(CreateAddressDto newAddressDto)
    {
        Address newAddress = new Address
        {
            Number = newAddressDto.Number,
            Street = newAddressDto.Street,
            MainStreet = newAddressDto.MainStreet,
            Suburb = newAddressDto.Suburb,
            Country = newAddressDto.Country,
            PostCode = newAddressDto.PostCode,
            ModelGUID = Guid.NewGuid().ToString(),
            CreatedDateTime = newAddressDto.CreatedDateTime.ToString(),
            Lat = newAddressDto.Lat,
            lon = newAddressDto.lon,
            CreatorId = newAddressDto.CreatorGuid,
            UserGuid = newAddressDto.UserGuid,
        };

        _context.Add(newAddress);
        await _context.SaveChangesAsync();
        return Ok(newAddress);
    }

    [HttpDelete]
    [Route("~/api/Address/Delete")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var address = await _context.Addresses
            .FirstOrDefaultAsync(m => m.Id == id);
        if (address == null)
        {
            return NotFound();
        }

        return View(address);
    }

    private List<AddressDto> ConvertToDto(List<Address> argument) {

        var response = new List<AddressDto>();

        foreach (var item in argument)
        {
            AddressDto Address = new AddressDto
            {
                Number = item.Number,
                Street = item.Street,
                MainStreet = item.MainStreet,
                Suburb = item.Suburb,
                Country = item.Country,
                PostCode = item.PostCode,
                ModelGuid = item.ModelGUID,
                CreatedDateTime = DateTime.TryParse( item.CreatedDateTime  ,out var date ) ? date : DateTime.Now,
                Lat = item.Lat,
                lon = item.lon,
                UserGuid = item.UserGuid
            };
            response.Add(Address);
        }
        return response;
    }

    private List<Address> ConvertToDomainModel(List<AddressDto> argument)
    {
        var response = new List<Address>();

        foreach (var item in argument)
        {

            Address Address = new Address
            {
                Number = item.Number,
                Street = item.Street,
                MainStreet = item.MainStreet,
                Suburb = item.Suburb,
                Country = item.Country,
                PostCode = item.PostCode,
                ModelGUID = item.ModelGuid,
                CreatedDateTime = item.CreatedDateTime.ToString(),
                Lat = item.Lat,
                lon = item.lon
            };
            response.Add(Address);
        }
        return response;
    }

    private bool AddressExists(int id)
    {
        return _context.Addresses.Any(e => e.Id == id);
    }
}
