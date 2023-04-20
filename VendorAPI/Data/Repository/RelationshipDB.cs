using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class RelationshipDB : IRelationship
    {
        public async Task<RelationshipDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelationshipDto>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelationshipDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelationshipDto>> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<RelationshipDto> Post(RelationshipDto model)
        {
            throw new NotImplementedException();
        }        
        
        public async Task<RelationshipDto> Post(CreateRelationshipDto model)
        {
            throw new NotImplementedException();
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
