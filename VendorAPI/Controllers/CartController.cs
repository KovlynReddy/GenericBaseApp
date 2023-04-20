using AutoMapper;
using GenericAppDLL.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly VendorContext _context;
        private readonly ICartDB _cartDB;
        private readonly IPurchaseDB _purchaseDB;
        private readonly IMapper mapper;

        public CartController(VendorContext context,ICartDB cartDB , IPurchaseDB purchaseDB,IMapper mapper)
        {
            _context = context;
            this._cartDB = cartDB;
            this._purchaseDB = purchaseDB;
            this.mapper = mapper;
        }

        [Route("~/api/Cart/{id}/{headers}")]
        [HttpGet]
        public async Task<IActionResult> Get(string id, string headers)
        {
            var results = await _purchaseDB.Get(id);

            return Ok(results);

        }

        [Route("~/api/Cart")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePurchaseDto newCart)
        {
            var dto = mapper.Map<PurchaseDto>(newCart);
            await _purchaseDB.Post(dto);
            return Ok();

        }        
        
        [Route("~/api/Cart/{cartId}")]
        [HttpPut]
        public async Task<IActionResult> Put(string cartId)
        {
            var trolley = await _cartDB.Get(cartId);
            var purchases = await _purchaseDB.Get(cartId);

            foreach (var item in trolley)
            {
                item.IsPaid = 1;
            }
            var purchase = purchases.FirstOrDefault();
            purchase.IsPaid = 1;
            var currentPurchase = purchase;

            await _purchaseDB.Put(currentPurchase);
            await _cartDB.Put(trolley.ToList());

            return Ok();

        }

        [Route("~/api/Cart")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PurchaseViewModel newCart)
        {

            return Ok();

        }
  
        
        [Route("~/api/Cart")]
        [HttpPatch]
        public async Task<IActionResult> Patch(PurchaseViewModel newCart)
        {

            return Ok();

        }





    }
}
