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

        [Route("~/api/Cart/Item/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {

            var results = await _cartDB.Get(Id);

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

        [Route("~/api/Cart/Item")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePurchaseItemDto newCart)
        {
            var dto = mapper.Map<PurchaseItemDto>(newCart);
            await _cartDB.Post(dto);

            var items = await _cartDB.Get(newCart.CartId);
            var purchases = await _purchaseDB.Get(newCart.CartId);                                                                                                                                                                                                                                                                                  

            var total = items.Sum(m=>m.Total);
            var purchase = purchases.FirstOrDefault();
            purchase.Total = total;   


            await _purchaseDB.Put(purchase);

            return Ok();

        }

        [Route("~/api/Cart")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PurchaseViewModel newCart)
        {

            return Ok();

        }

        [Route("~/api/Cart/Item")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PurchaseItemViewModel newCart)
        {

            return Ok();

        }        
        
        [Route("~/api/Cart")]
        [HttpPatch]
        public async Task<IActionResult> Patch(PurchaseViewModel newCart)
        {

            return Ok();

        }

        [Route("~/api/Cart/Item")]
        [HttpPatch]
        public async Task<IActionResult> Patch(PurchaseItemViewModel newCart)
        {

            return Ok();

        }



    }
}
