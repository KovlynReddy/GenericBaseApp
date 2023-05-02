using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class PointsDB : IPointsDB
    {
        private readonly VendorContext _context;
        public IMapper mapper { get; }

        public PointsDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<PointsDto> Post(PointsDto model)
        {
            var entity = mapper.Map<Points>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return model;
        }

        public async Task<PointsDto> Put(PointsDto model)
        {
            var entity = _context.Points.FirstOrDefault(m => m.ModelGUID == model.ModelGuid);
            //var rawResult = _context.Update(entity);
            var IsPaid = _context.Entry(entity).Property("Status").IsModified;
            _context.SaveChanges();

            return model;
        }

        public async Task<List<PointsDto>> Put(List<PointsDto> model)
        {
            throw new NotImplementedException();
        }

        public async Task<PointsDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PointsDto>> Get()
        {
            var rawResult = _context.Points.ToList();
            var results = mapper.Map<List<PointsDto>>(rawResult);
            return results;
        }

        public async Task<IEnumerable<PointsDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PointsDto>> Get(string Id)
        {
            var rawResult = _context.Points.Where(m => m.AccountGuid == Id ||m.CreatorId == Id || m.UserGuid == Id || m.ModelGUID == Id).ToList();
            var results = mapper.Map<List<PointsDto>>(rawResult);
            return results;
        }
    }
}
