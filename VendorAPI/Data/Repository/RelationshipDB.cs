using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class RelationshipDB : IRelationship
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public RelationshipDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<RelationshipDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelationshipDto>> Get()
        {
            var rawresults = _context.Relationships.ToList();
            var results = mapper.Map<List<RelationshipDto>>(rawresults);

            return results;
        }

        public async Task<IEnumerable<RelationshipDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelationshipDto>> Get(string Id)
        {
            var rawresults = _context.Relationships.Where(m=>m.SenderId == Id || m.RecieverId == Id).ToList();
            var results = mapper.Map<List<RelationshipDto>>(rawresults);

            return results;
        }

        public async Task<RelationshipDto> Post(RelationshipDto model)
        {
            var dmodel = mapper.Map<Relationship>(model);
            _context.Relationships.Add(dmodel);
            _context.SaveChanges();

            return model;
        }        
        
        public async Task<RelationshipDto> Post(CreateRelationshipDto model)
        {
            var dmodel = mapper.Map<Relationship>(model);
            _context.Relationships.Add(dmodel);
            _context.SaveChanges();

            var dto = mapper.Map<RelationshipDto>(model);
            return dto;
        }

        public async Task<RelationshipDto> Put(RelationshipDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationshipDto>> Put(List<RelationshipDto> model)
        {
            throw new NotImplementedException();
        }
    }
}
