namespace VendorAPI.Data.Interface
{
    public interface IBase<T>
    {
        T Post();
        IEnumerable<T> Get();
        T Get(int Id);
        T Put(T model);
        T Delete(int Id);
    }
}
