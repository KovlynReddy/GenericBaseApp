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

        public CartController(VendorContext context,ICartDB cartDB , IPurchaseDB purchaseDB)
        {
            _context = context;
            this._cartDB = cartDB;
            this._purchaseDB = purchaseDB;
        }

        [Route("~/api/Cart/{id}/{headers}")]
        [HttpGet]
        public async Task<IActionResult> Get(string id, string headers)
        {
            _cartDB.Get(id);

            return Ok();

        }

        [Route("~/api/Cart/Item/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            _purchaseDB.Get(Id);

            return Ok();

        }



        [Route("~/api/Cart")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePurchaseItemDto newCart)
        {

            await _cartDB.Post(new PurchasedItem()
            {
                Amount = newCart.Amount,
                CartId = newCart.CartId,
                Cost = newCart.Cost,
                CreatedDateTime = newCart.DatePurchased,
                IsPaid = 0,
                ItemGuid = newCart.ItemGuid,
                ModelGUID = newCart.ModelGuid,
            });
            return Ok();

        }

        [Route("~/api/Cart/Item")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePurchaseDto newCart)
        {
            await _purchaseDB.Post(new Purchase()
            {
                Amount = newCart.Amount,
                CartId = newCart.CartId,
                Cost = newCart.Cost,
                CreatedDateTime = newCart.DatePurchased,
                Currency = newCart.Currency,
                IsPaid = 0,
                ModelGUID = newCart.ModelGuid,
                Total = newCart.Total
            });

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
