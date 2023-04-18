using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class PurchaseDB : IPurchaseDB
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public PurchaseDB(VendorContext context , IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<PurchaseDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseDto>> Get()
        {
            var rawResult = _context.Purchases.ToList();
            return mapper.Map<List<PurchaseDto>>(rawResult);
        }

        public async Task<IEnumerable<PurchaseDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseDto>> Get(string Id)
        {
            var rawResult = _context.Purchases.Where(m => m.CreatorId == Id || m.CartId == Id || m.ModelGUID == Id).ToList();
            return mapper.Map<List<PurchaseDto>>(rawResult);
        }

        public async Task<PurchaseDto> Post(PurchaseDto model)
        {
            var entity = mapper.Map<Purchase>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return mapper.Map<PurchaseDto>(rawResult);
        }

        public async Task<PurchaseDto> Put(PurchaseDto model)
        {
            var entity = mapper.Map<Purchase>(model);
            var rawResult = _context.Update(entity);
            _context.SaveChanges();

            return mapper.Map<PurchaseDto>(rawResult.Entity);
        }

    }
}
