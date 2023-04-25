﻿using Microsoft.AspNetCore.Mvc;

namespace VendorAPI.Controllers
{
    [Route("api/MeetupRequest")]
    [ApiController]
    public class MeetupRequestController : Controller
    {
        [HttpGet]
        [Route("~/api/MeetupRequest")]
        public async Task<IActionResult> Get()
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/MeetupRequest/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/MeetupRequest")]
        public async Task<IActionResult> Post()
        {
            return View();
        }

        [HttpPut]
        [Route("~/api/MeetupRequest")]
        public async Task<IActionResult> Put()
        {
            return View();
        }

    }
}
