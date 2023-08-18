using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class AdvertisingDB : IAdvertsDB
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public AdvertisingDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public Task<AdvertisingDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdvertisingDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdvertisingDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdvertisingDto>> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertisingDto> Post(AdvertisingDto model)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertisingDto> Put(AdvertisingDto model)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisingDto>> Put(List<AdvertisingDto> model)
        {
            throw new NotImplementedException();
        }
    }
}
