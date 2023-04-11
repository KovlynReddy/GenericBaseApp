using GenericAppDLL.Models.DomainModel;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class DirectMessageDB : IBase<DirectMessageDto>
    {
        private readonly VendorContext _context;

        public DirectMessageDB(VendorContext context)
        {
            _context = context;
        }

        public async Task<DirectMessageDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DirectMessageDto>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DirectMessageDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DirectMessageDto>> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<DirectMessageDto> Post(DirectMessageDto model)
        {
            DM newEntity = new DM() { 
            Message = model.Message, 
            SenderGuid = model.SenderGuid,
            RecieverGuid = model.RecieverGuid,
            ModelGUID = model.ModelGuid,
            CreatedDateTime = DateTime.Now.ToString(),
            };

            await _context.Messages.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<DirectMessageDto> Put(DirectMessageDto model)
        {
            throw new NotImplementedException();
        }
    }
}
