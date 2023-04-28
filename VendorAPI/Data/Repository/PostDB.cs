using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class PostDB : IPostDB
    {
        public VendorContext _context { get; }
        public IMapper mapper { get; }

        public PostDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<Post> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            var rawResult = _context.JournalEntries.ToList();
            return mapper.Map<List<PostDto>>(rawResult);
        }

        public async Task<IEnumerable<PostDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostDto>> Get(string Id)
        {
            var rawResult = _context.JournalEntries.Where(m => m.CreatorId == Id || m.UserGuid == Id || m.ModelGUID == Id).ToList();
            var results = mapper.Map<List<PostDto>>(rawResult);
            return results;
        }

        public async Task<PostDto> Post(PostDto model)
        {
            var entity = mapper.Map<Post>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return model;
        }

        public Task<PostDto> Put(PostDto model)
        {
            throw new NotImplementedException();
        }

        Task<PostDto> IPostDB.Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
