using GenericAppDLL.Models.DomainModel;

namespace VendorAPI.Data.Interface
{
    public interface IPostDB
    {
        Task<PostDto> Post(PostDto model);
        Task<IEnumerable<PostDto>> Get();
        Task<IEnumerable<PostDto>> Get(int Id);
        Task<IEnumerable<PostDto>> Get(string Id);
        Task<PostDto> Put(PostDto model);
        Task<PostDto> Delete(int Id);
    }
}
