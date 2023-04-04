namespace GenericBaseMVC.Services.ServiceInterface
{
    public interface IBase<T>
    {
        T Post();
        IEnumerable<T> Get();
        T Get(int Id);
        T Get(string Id);
        T Put(T model);
        T Delete(int Id);
    }
}
