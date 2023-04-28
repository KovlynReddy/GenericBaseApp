using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class JournalDB : IJournalDB
    {
        public VendorContext _context { get; }
        public IMapper mapper { get; }

        public JournalDB(VendorContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }


        public async Task<JournalEntryDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JournalEntryDto>> Get()
        {
            var rawResult = _context.JournalEntries.ToList();
            return mapper.Map<List<JournalEntryDto>>(rawResult);
        }

        public async Task<IEnumerable<JournalEntryDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JournalEntryDto>> Get(string Id)
        {
            var rawResult = _context.JournalEntries.Where(m => m.CreatorId == Id || m.UserGuid == Id || m.ModelGUID == Id).ToList();
            var results = mapper.Map<List<JournalEntryDto>>(rawResult);
            return results;
        }

        public async Task<JournalEntryDto> Post(JournalEntryDto model)
        {
            var entity = mapper.Map<JournalEntry>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return mapper.Map<JournalEntryDto>(rawResult);
        }

        public async Task<JournalEntryDto> Put(JournalEntryDto model)
        {
            var entity = mapper.Map<JournalEntry>(model);
            var rawResult = _context.Update(entity);
            _context.SaveChanges();

            return mapper.Map<JournalEntryDto>(rawResult.Entity);
        }

        public async Task<List<JournalEntryDto>> Put(List<JournalEntryDto> model)
        {
            var dmodel = mapper.Map<List<JournalEntry>>(model);
            var dlist = dmodel.ToList();
            //var rawResult = _context.UpdateRange(dlist);

            foreach (var item in dmodel)
            {
                //var result = _context.Update(item);
                var ditem = _context.JournalEntries.FirstOrDefault(m => m.ModelGUID == item.ModelGUID || m.Id == item.Id);
                var IsPaid = _context.Entry(ditem).Property("IsPaid").IsModified;

                _context.SaveChanges();
            }

            //return mapper.Map<JournalEntryDto>(rawResult.Entity);
            return new List<JournalEntryDto>();
        }
    }
}
