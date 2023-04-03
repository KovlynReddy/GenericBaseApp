using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class DirectMessageDB : IBase<DirectMessageDto>
    {
        public Task<DirectMessageDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DirectMessageDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<DirectMessageDto> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<DirectMessageDto> Post(DirectMessageDto model)
        {
            throw new NotImplementedException();
        }

        public Task<DirectMessageDto> Put(DirectMessageDto model)
        {
            throw new NotImplementedException();
        }
    }
}
