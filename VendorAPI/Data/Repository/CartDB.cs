﻿    using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class CartDB : ICartDB
    {
        private readonly VendorContext _context;
        private readonly IMapper mapper;

        public CartDB(VendorContext context , IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<PurchaseItemDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseItemDto>> Get()
        {
            var rawResult = _context.PurchasedItems.ToList();
            return mapper.Map<List<PurchaseItemDto>>(rawResult);
        }

        public async Task<IEnumerable<PurchaseItemDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseItemDto>> Get(string Id)
        {
            var rawResult = _context.PurchasedItems.Where(m => m.CreatorId == Id || m.CartId == Id || m.ModelGUID == Id).ToList();
            var results = mapper.Map<List<PurchaseItemDto>>(rawResult);
            return results;
        }

        public async Task<PurchaseItemDto> Post(PurchaseItemDto model)
        {
            var entity = mapper.Map<PurchasedItem>(model);
            var rawResult = _context.Add(entity);
            _context.SaveChanges();

            return mapper.Map<PurchaseItemDto>(rawResult);
        }

        public async Task<PurchaseItemDto> Put(PurchaseItemDto model)
        {
            var entity = mapper.Map<PurchasedItem>(model);
            var rawResult = _context.Update(entity);
            _context.SaveChanges();

            return mapper.Map<PurchaseItemDto>(rawResult.Entity);
        }

        public async Task<List<PurchaseItemDto>> Put(List<PurchaseItemDto> model)
        {
            var dmodel = mapper.Map<List<PurchasedItem>>(model);
            var dlist = dmodel.ToList();
            //var rawResult = _context.UpdateRange(dlist);

            foreach (var item in dmodel)
            {
                //var result = _context.Update(item);
                var ditem = _context.PurchasedItems.FirstOrDefault(m=>m.ModelGUID == item.ModelGUID || m.Id == item.Id);
                ditem.IsPaid = item.IsPaid;
                var IsPaid = _context.Entry(ditem).Property("IsPaid").IsModified;
                
                _context.SaveChanges();
            }

            //return mapper.Map<PurchaseItemDto>(rawResult.Entity);
            return new List<PurchaseItemDto>();
        }
    }
}
