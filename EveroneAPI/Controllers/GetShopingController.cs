using System.Collections.Generic;
using System.Linq;
using EveroneAPI.Comoon;
using EveroneAPI.ContextDB;
using EveroneAPI.ContextDB.Models;
using EveroneAPI.Filter;
using EveroneAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EveroneAPI.Controllers
{

    [EnableCors("any")]
    [ServiceFilter(typeof(TokenFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class GetShopingController : ControllerBase
    {

        private readonly ContextDBs db;
    
        public GetShopingController(ContextDBs _db )
        {
             
            db = _db;
        }
        /// <summary>
        /// 获取奶茶图片
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        //获取奶茶图片
        [HttpPost("shopingimage")]
        public IEnumerable<shoping> Shopingimag(string access_token)
        {
            //return db.shoping.ToList();
            return null;
        }
        /// <summary>
        /// 购买奶茶
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="buy"></param>
        /// <returns></returns>
        //购买奶茶
        [HttpPost("Buy")]
        public ReturnModel Buy(string? access_token,[FromBody]Buy buy)
        {
            var ret = new ReturnModel();
            var data = new Buy()
            {
                ID = buy.ID,
                Name = buy.Name,
                Sugarcontent=buy.Sugarcontent,
                Number=buy.Number,
                Price=buy.Price,
                temperature=buy.temperature
            };
            //db.Buy.Add(data);
            //db.SaveChanges();
            ret.Code = 200;
            ret.Msg = "购买成功";

            return ret;
        }

    }
}










     //foreach (var item in usess)
     //       {
     //               ret.ID = item.ID;
     //               ret.Price = item.Price;
     //               ret.style = item.style;
     //               ret.title = item.title;
     //               ret.Url = item.Url;
     //               ret.details = item.details;
     //               ret.Discount = item.Discount;
     //               ret.Code = item.Code;
     //               ret.Msg = "获取成功";
     //               return ret;
             
              
     //       }