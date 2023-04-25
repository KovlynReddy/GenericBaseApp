using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class MeetupRequestDB : IMeetupRequestDB
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public MeetupRequestDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<MeetupRequestDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MeetupRequestDto>> Get()
        {
            var results = _context.MeetUpRequests.ToList();

            return mapper.Map<List<MeetupRequestDto>>(results);
        }

        public async Task<IEnumerable<MeetupRequestDto>> Get(int Id)
        {
            var results = _context.MeetUpRequests.Where(m => m.MeetupGuid == Id.ToString() || m.SenderGuid == Id.ToString() || m.ModelGUID == Id.ToString() || m.ReaderGuid == Id.ToString()).ToList();


            return mapper.Map<List<MeetupRequestDto>>(results);
        }

        public async Task<IEnumerable<MeetupRequestDto>> Get(string Id)
        {
            var results = _context.MeetUpRequests.Where(m => m.MeetupGuid == Id || m.SenderGuid == Id || m.ModelGUID == Id || m.ReaderGuid == Id).ToList();


            return mapper.Map<List<MeetupRequestDto>>(results);
        }

        public async Task<MeetupRequestDto> Post(MeetupRequestDto model)
        {
            var entity = mapper.Map<PostInteraction>(model);

            _context.Add(entity);
            _context.SaveChanges();

            return model;
        }

        public async Task<MeetupRequestDto> Put(MeetupRequestDto model)
        {
            var entity = _context.MeetUpRequests.FirstOrDefault(m => m.ModelGUID == model.ModelGuid);
            //var rawResult = _context.Update(entity);
            entity.Status = model.Status;
            var IsPaid = _context.Entry(entity).Property("Status").IsModified;
            _context.SaveChanges();

            return model;
        }

        public async Task<List<MeetupRequestDto>> Put(List<MeetupRequestDto> model)
        {
            throw new NotImplementedException();
        }
    }
}
