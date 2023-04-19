using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class ItemDB : IItemDB
    {
        public Task<Item> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Post(Item model)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Put(Item model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> Put(List<Item> model)
        {
            throw new NotImplementedException();
        }
    }
}
