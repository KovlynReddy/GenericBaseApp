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
            this.mapper = mapper;
        }

        public Task<CustomerDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Get()
        {
            var rawResult = _context.Customers.ToList();
            return mapper.Map<List<CustomerDto>>(rawResult);
        }

        public async Task<IEnumerable<CustomerDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> Get(string Id)
        {
            var rawResult = _context.Customers.Where(m => m.Email == Id || m.CustomerEmail == Id || m.AccountGuid == Id || m.ModelGUID == Id).ToList();
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

        public async Task<CustomerDto> Put(CustomerDto model)
        {
            var entity = _context.Customers.FirstOrDefault(m => m.ModelGUID == model.ModelGuid);
            entity.AccountGuid = model.AccountGuid;
            //var rawResult = _context.Update(entity);
            var AccountId = _context.Entry(entity).Property("AccountGuid").IsModified;
            _context.SaveChanges();

            return model;
        }

        public Task<List<CustomerDto>> Put(List<CustomerDto> model)
        {
            throw new NotImplementedException();
        }
    }
}
