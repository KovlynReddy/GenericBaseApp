using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class PostInteractionDB : IPostInteractionDB
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public PostInteractionDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<PostInteractionDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostInteractionDto>> Get()
        {
            var results = _context.PostInteractions.ToList();

            return mapper.Map<List<PostInteractionDto>>(results);
        }

        public async Task<IEnumerable<PostInteractionDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostInteractionDto>> Get(string Id)
        {
            var results = _context.PostInteractions.Where(m=> m.PostGuid == Id || m.SenderGuid == Id || m.ModelGUID == Id || m.ReaderGuid == Id).ToList();


            return mapper.Map<List<PostInteractionDto>>(results);
        }

        public async Task<PostInteractionDto> Post(PostInteractionDto model)
        {
            var entity = mapper.Map<PostInteraction>(model);

            _context.Add(entity);
            _context.SaveChanges();

            return model;
        }

        public async Task<PostInteractionDto> Put(PostInteractionDto model)
        {
            var entity = _context.PostInteractions.FirstOrDefault(m => m.ModelGUID == model.ModelGuid);
            //var rawResult = _context.Update(entity);
            entity.Status = model.Status;
            var IsPaid = _context.Entry(entity).Property("Status").IsModified;
            _context.SaveChanges();

            return model;
        }

        public async Task<List<PostInteractionDto>> Put(List<PostInteractionDto> model)
        {
            throw new NotImplementedException();
        }
    }
}
