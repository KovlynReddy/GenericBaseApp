namespace VendorAPI.Data.Interface
{
    public interface IBase<T>
    {
        Task<T> Post(T model);
        Task<IEnumerable<T>> Get();
        Task<T> Get(int Id);
        Task<T> Put(T model);
        Task<T> Delete(int Id);
    }
}
