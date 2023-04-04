namespace VendorAPI.Data.Interface
{
    public interface IBase<T>
    {
        Task<T> Post(T model);
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(int Id);
        Task<IEnumerable<T>> Get(string Id);
        Task<T> Put(T model);
        Task<T> Delete(int Id);
    }
}
