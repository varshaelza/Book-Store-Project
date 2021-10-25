using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Book_Store_Project.Models;
namespace Book_Store_Project.Controllers
{
    public class CartController : ApiController
    {
        

        [HttpGet]
        public List<Cart> GetCart()
        {
            List<Cart> cartList = new List<Cart>();
            try
            {
                Cart cart = new Cart();
                cartList = cart.GetAllItems();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return cartList;
        }

        [HttpGet]
        public List<Cart> GetCart(int userId)
        {
            List<Cart> cartList = new List<Cart>();
            try
            {
                Cart cart = new Cart();
                cartList = cart.GetbyUserId(userId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return cartList;
        }

        [HttpPost]
        public List<Cart> PostCart(Cart newObj)
        {
            Cart cart = new Cart();
            try
            {
                cart.AddItem(newObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return cart.GetAllItems();
  
        }
        [HttpPut]
        public List<Cart> PutCart(int id, Cart updObj)
        {
            Cart cart = new Cart();
            try
            {
                cart.UpdateItem(id, updObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            
            return cart.GetAllItems();
        }
        [HttpDelete]
        public List<Cart> DeleteCart(int id)
        {
            Cart cart = new Cart();
            try
            {
                cart.DeleteItem(id);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            
            return cart.GetAllItems();
        }
    }
}
