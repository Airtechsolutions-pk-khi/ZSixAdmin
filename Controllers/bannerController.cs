﻿
using System.Collections.Generic;
using ZSixRestaurantAdmin._Models;
using ZSixRestaurantAdmin.BLL._Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ZSixRestaurantAdmin.Controllers
{
    [Route("api/[controller]")]
  
    public class bannerController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        bannerService _service;
        public bannerController(IWebHostEnvironment env)
        {
            _service = new bannerService();
            _env = env;
        }

        [HttpGet("all/{brandid}")]
        public List<BannerBLL> GetAll(int brandid)
        {
            return _service.GetAll(brandid);
        }


        [HttpGet("{id}/brand/{brandid}")]
        public BannerBLL Get(int id, int brandid)
        {
            return _service.Get(id, brandid);
        }

        [HttpPost]
        [Route("insert")]
        public int Post([FromBody]BannerBLL obj)
        {
            return _service.Insert(obj, _env);
        }

        [HttpPost]
        [Route("update")]
        public int PostUpdate([FromBody]BannerBLL obj)
        {
            return _service.Update(obj, _env);
        }


        [HttpPost]
        [Route("delete")]
        public int PostDelete([FromBody]BannerBLL obj)
        {
            return _service.Delete(obj);
        }
    }
}
