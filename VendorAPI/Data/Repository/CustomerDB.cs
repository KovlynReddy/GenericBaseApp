using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class CustomerDB : ICustomer
    {
        public Task<Customer> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Post(Customer model)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Put(Customer model)
        {
            throw new NotImplementedException();
        }

    }
}
