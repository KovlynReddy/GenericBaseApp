namespace VendorAPI.Data.Interface
{
    public interface IDirectMessagesDB
    {
        DirectMessage Post();
        IEnumerable<DirectMessage> Get();
        DirectMessage Get(int Id);
        DirectMessage Put(DirectMessage model);
        DirectMessage Delete(int Id);
    }
}
