using AutoMapper;
using GenericAppDLL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly VendorContext _context;
        private readonly ICartDB _cartDB;
        private readonly IPurchaseDB _purchaseDB;
        private readonly IMapper mapper;

        public ShopController(VendorContext context, ICartDB cartDB, IPurchaseDB purchaseDB, IMapper mapper)
        {
            _context = context;
            this._cartDB = cartDB;
            this._purchaseDB = purchaseDB;
            this.mapper = mapper;
        }

        [Route("~/api/Shop/Item/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {

            var results = await _cartDB.Get(Id);

            return Ok(results);

        }

        [Route("~/api/Shop/Item")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePurchaseItemDto newCart)
        {
            var dto = mapper.Map<PurchaseItemDto>(newCart);
            await _cartDB.Post(dto);

            var items = await _cartDB.Get(newCart.CartId);
            var purchases = await _purchaseDB.Get(newCart.CartId);

            var total = items.Sum(m => m.Total);
            var purchase = purchases.FirstOrDefault();
            purchase.Total = total;


            await _purchaseDB.Put(purchase);

            return Ok();

        }

        [Route("~/api/Shop/Item")]
        [HttpDelete]
        public async Task<IActionResult> Delete(PurchaseItemViewModel newCart)
        {

            return Ok();

        }

        [Route("~/api/Shop/Item")]
        [HttpPatch]
        public async Task<IActionResult> Patch(PurchaseItemViewModel newCart)
        {

            return Ok();

        }
    }
}
