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

    // GET: Addresses
    [HttpGet]
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
    public async Task<IActionResult> GetUsersAddress(string id) {
        var response = ConvertToDto(await _context.Addresses.Where(m=>m.CreatorId==id).ToListAsync());

        return Ok(response);
    }

    [HttpPost]
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

    // GET: Addresses/Details/5
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

    // GET: Addresses/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Addresses/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Number,Street,MainStreet,Suburb,PostCode,Country,Lat,lon,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Address address)
    {
        if (ModelState.IsValid)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

    // GET: Addresses/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        return View(address);
    }

    // POST: Addresses/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Number,Street,MainStreet,Suburb,PostCode,Country,Lat,lon,Id,ModelGUID,IsDeleted,CreatedDateTime,DeletedDateTime,CompletedDateTime,CreatorId")] Address address)
    {
        if (id != address.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(address);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address.Id))
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
        return View(address);
    }

    // GET: Addresses/Delete/5
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

    // POST: Addresses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
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
