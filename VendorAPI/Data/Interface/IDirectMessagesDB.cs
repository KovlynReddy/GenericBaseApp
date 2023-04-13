namespace VendorAPI.Data.Interface
{
    public interface IDirectMessagesDB : IBase<DirectMessageDto>
    {
        Task<IEnumerable<DirectMessageDto>> Get(string id,string email);
    }
}
