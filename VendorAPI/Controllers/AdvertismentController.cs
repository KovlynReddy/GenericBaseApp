﻿using Microsoft.AspNetCore.Mvc;
using VendorAPI.Data.Interface;

namespace VendorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertismentController : Controller
    {
        private readonly VendorContext _context;
        private readonly IAdvertsDB _db;

        public AdvertismentController(VendorContext context, IAdvertsDB db)
        {
            _context = context;
            _db = db;
        }

        [Route("~/api/advertisment")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var adverts = await _db.Get();

            //foreach (var advert in adverts)
            //{
            //    advert.ImagePath01 = advert.ImagePath02.Split();
            //}

            return Ok(adverts);
        }

        [Route("~/api/advertisment/{email}")]
        [HttpGet("GetAll/{email}")]
        public async Task<IActionResult> GetAll(string? email)
        {
            var adverts = await _db.Get();

            foreach (var advert in adverts)
            {
                var paths1 = advert.ImagePath01.Split("\\");
                advert.ImagePath01 = paths1.Last();      
                
                var paths2 = advert.ImagePath02.Split("\\");
                advert.ImagePath02 = paths2.Last();  
                
                var paths3 = advert.ImagePath03.Split("\\");
                advert.ImagePath03 = paths3.Last();
            }

            return Ok(adverts);
        }

        [Route("~/api/advertisment/CreateDto")]
        [HttpPost("CreateDto")]
        public async Task<IActionResult> Post(AdvertisingDto dto)
        {
            var results = await _db.Post(dto);

            return Ok(results);
        }
    }
}
