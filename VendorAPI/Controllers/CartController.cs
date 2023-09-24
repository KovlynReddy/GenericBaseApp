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

        public ICustomer CustomerDb { get; }
        public IPointsDB _pointsDb { get; }

        public CartController(VendorContext context,ICartDB cartDB , IPurchaseDB purchaseDB,IMapper mapper, IPointsDB pointsDb, ICustomer customerDb)
        {
            _context = context;
            _pointsDb = pointsDb;
            this._cartDB = cartDB;
            this._purchaseDB = purchaseDB;
            this.mapper = mapper;
            CustomerDb = customerDb;
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
        
        [Route("~/api/Cart")]
        [HttpPut]
        public async Task<IActionResult> Put(PurchaseCartDto cart)
        {
            var trolley = await _cartDB.Get(cart.CartId);
            var purchases = await _purchaseDB.Get(cart.CartId);

            foreach (var item in trolley)
            {
                item.IsPaid = 1;
            }
            var purchase = purchases.FirstOrDefault();
            purchase.IsPaid = 1;
            var currentPurchase = purchase;

            await _purchaseDB.Put(currentPurchase);
            await _cartDB.Put(trolley.ToList());

            var items = await _cartDB.Get(cart.CartId);
            var total = items.Sum(m => m.Cost);

            if (cart.Type == 1)
            {
                var owner = (await CustomerDb.Get(cart.OwnerGuid)).FirstOrDefault();
                PointsDto newDto = new PointsDto()
                {
                    AccountGuid = owner.AccountGuid,
                    Description = "Trolley Purchased",
                    Type = 5,
                    SenderType = 5,
                    UserGuid = owner.ModelGuid,
                    ModelGuid = Guid.NewGuid().ToString(),
                    Amount = -1 * total * 10,
                    CreatedDateTime = DateTime.Now.ToString(),
                };

                //var dto = Mapper.Map<PointsDto>(newDto);
                var accountId = owner.AccountGuid;
                if (string.IsNullOrEmpty(owner.AccountGuid))
                {
                    accountId = Guid.NewGuid().ToString();
                    owner.AccountGuid = accountId;
                    await CustomerDb.Put(owner);
                }
                newDto.AccountGuid = accountId;

                var result = await _pointsDb.Post(newDto);
            }

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
