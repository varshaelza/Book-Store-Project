using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Book_Store_Application.Models;

namespace Book_Store_Application.Controllers
{
    public class WishListController : ApiController
    {
        public List<WishList> GetAllWishList()
        {
            WishList wishObj = new WishList();
            List<WishList> WishesList = new List<WishList>();
            try
            {
                WishesList= wishObj.GetAllWishList();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return WishesList;

        }

        [HttpGet]
        public List<WishList> GetWishListById(int p_userId)
        {
            WishList wishObj = new WishList();
            List<WishList> WishesList = new List<WishList>();
            try
            {
                WishesList = wishObj.GetbyUserId(p_userId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return WishesList;
        }

        [HttpPost]
        public List<WishList> PostWishList(WishList p_wishObj)
        {
            WishList wishObj = new WishList();
            try
            {
                wishObj.AddWishList(p_wishObj);
            }
            catch(Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return wishObj.GetAllWishList();
        }

        [HttpPut]
        public List<WishList> PutWishList(WishList p_wishObj)
        {
            WishList wishObj = new WishList();
            try
            {
                wishObj.UpdateWishList(p_wishObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return wishObj.GetAllWishList();
        }

        [HttpDelete]
        public List<WishList> DeleteWishList(int p_wishId)
        {
            WishList wishObj = new WishList();
            try
            {
                wishObj.DeleteWishList(p_wishId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return wishObj.GetAllWishList();
        }
    }
}
