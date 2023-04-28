using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class CustomerDB : ICustomer
    {
        private readonly VendorContext _context;
        public IMapper mapper { get; }

        public CustomerDB(VendorContext context, IMapper mapper)
        {
            _context = context;
        }

        public Task<CustomerDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Get()
        {
            var rawResult = _context.JournalEntries.ToList();
            return mapper.Map<List<CustomerDto>>(rawResult);
        }

        public async Task<IEnumerable<CustomerDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Get(string Id)
        {
            var rawResult = _context.JournalEntries.Where(m => m.CreatorId == Id || m.UserGuid == Id || m.ModelGUID == Id).ToList();
            var results = mapper.Map<List<CustomerDto>>(rawResult);
            return results;
        }

        public async Task<CustomerDto> Post(CustomerDto model)
        {
            var entity = mapper.Map<Customer>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return model;
        }

        public Task<CustomerDto> Put(CustomerDto model)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerDto>> Put(List<CustomerDto> model)
        {
            throw new NotImplementedException();
        }
    }
}
