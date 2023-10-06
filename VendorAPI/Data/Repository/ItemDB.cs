using AutoMapper;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class ItemDB : IItemDB
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public ItemDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public Task<Item> Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<MenuItemDto>> Get(string Id)
        {
            var rawResult = _context.Items.Where(m => m.CreatorId == Id || m.VendorId == Id || m.ModelGUID == Id).ToList();
            var results = mapper.Map<List<MenuItemDto>>(rawResult);
            return results;
        }
        public async Task<IEnumerable<MenuItemDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<MenuItemDto>> Get()
        {
            var rawResult = _context.Items.ToList();
            var results = mapper.Map<List<MenuItemDto>>(rawResult);
            return results;
        }

        public async Task<MenuItemDto> Post(MenuItemDto model)
        {
            var entity = mapper.Map<Item>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return mapper.Map<MenuItemDto>(rawResult);
        }

        public async Task<MenuItemDto> Put(MenuItemDto model)
        {
            var entity = mapper.Map<Item>(model);
            var rawResult = _context.Update(entity);
            _context.SaveChanges();

            return mapper.Map<MenuItemDto>(rawResult.Entity);
        }

        public async Task<List<MenuItemDto>> Put(List<MenuItemDto> model)
        {
            var dmodel = mapper.Map<List<Item>>(model);
            var dlist = dmodel.ToList();
            //var rawResult = _context.UpdateRange(dlist);

            foreach (var item in dmodel)
            {
                //var result = _context.Update(item);
                var ditem = _context.Items.FirstOrDefault(m => m.ModelGUID == item.ModelGUID || m.Id == item.Id);
                //ditem.IsPaid = item.IsPaid;
                var IsPaid = _context.Entry(ditem).Property("IsPaid").IsModified;

                _context.SaveChanges();
            }

            return new List<MenuItemDto>();
        }

        public Task<MenuItemDto> UpdateItem(string Id)
        {
            var entity = _context.Items.FirstOrDefault(m=>m.ModelGUID == Id);
            var journalEntries = _context.JournalEntries.Where(m=>m.ItemGuid==Id).ToList();

            entity.AverageRating = journalEntries.Select(m => m.Rating).Average();

            var AverageRating = _context.Entry(entity).Property("AverageRating").IsModified;
            _context.SaveChanges();

            throw new NotImplementedException();
        }

        Task<MenuItemDto> IBase<MenuItemDto>.Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
