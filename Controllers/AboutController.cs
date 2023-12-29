
using System.Collections.Generic;
using ZSixRestaurantAdmin._Models;
using ZSixRestaurantAdmin.BLL._Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ZSixRestaurantAdmin.Controllers
{
    [Route("api/[controller]")]
  
    public class AboutController : ControllerBase
    {        
        aboutService _service;
      
        public AboutController()
        {
            _service = new aboutService();
           
        }
        [HttpGet("brand/{brandid}")]
        public AboutBLL Get( int brandid)
        {
            return _service.Get( brandid);
        }
        [HttpPost]
        [Route("insert")]
        public int Post([FromBody]AboutBLL obj)
        {
            return _service.Insert(obj);
        }

        [HttpPost]
        [Route("update")]
        public int PostUpdate([FromBody] AboutBLL obj)
        {
            return _service.Update(obj);
        }


        //[HttpPost]
        //[Route("delete")]
        //public int PostDelete([FromBody]CategoryBLL obj)
        //{
        //    return _service.Delete(obj);
        //}
    }
}
