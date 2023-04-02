using GenericAppDLL.Models.DomainModel;

namespace VendorAPI.Data.Interface
{
    public interface IPostDB
    {
        Post Post();
        IEnumerable<Post> Get();
        Post Get(int Id);
        Post Put(Post model);
        Post Delete(int Id);
    }
}
