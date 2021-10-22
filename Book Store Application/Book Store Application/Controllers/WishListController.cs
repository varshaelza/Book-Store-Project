using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;

namespace Book_Store_Application.Controllers
{
    public class WishListController : ApiController
    {
        public List<WishList> GetAllWishList()
        {
            WishList wishObj = new WishList();
            return wishObj.GetAllWishList();
        }

        [HttpGet]
        public List<WishList> GetWishListById(int p_userId)
        {
            WishList wishObj = new WishList();
            return wishObj.GetbyUserId(p_userId);
        }

        [HttpPost]
        public List<WishList> PostWishList(WishList p_wishObj)
        { 
            WishList wishObj = new WishList();
            wishObj.AddWishList(p_wishObj);
            return wishObj.GetAllWishList();
        }

        [HttpPut]
        public List<WishList> PutWishList(WishList p_wishObj)
        {
            WishList wishObj = new WishList();
            wishObj.UpdateWishList(p_wishObj);
            return wishObj.GetAllWishList();
        }

        [HttpDelete]
        public List<WishList> DeleteWishList(WishList p_wishObj)
        {
            WishList wishObj = new WishList();
            wishObj.DeleteWishList(p_wishObj.wishId);
            return wishObj.GetAllWishList();
        }
    }
}
