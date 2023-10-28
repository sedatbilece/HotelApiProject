﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {

        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var value = _subscribeService.TGetById(id);
            if (value == null)
                return NotFound();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TInsert(Subscribe);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _subscribeService.TGetById(id);
            _subscribeService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TUpdate(Subscribe);
            return Ok();
        }
    }
}
