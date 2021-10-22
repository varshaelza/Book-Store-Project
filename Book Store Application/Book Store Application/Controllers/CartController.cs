using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Project.Models;
namespace Book_Store_Project.Controllers
{
    public class CartController : ApiController
    {
        Cart cart = new Cart();

        [HttpGet]
        public List<Cart> GetCart()
        {
            return cart.GetAllItems();
        }
        [HttpGet]
        public List<Cart> GetCart(int userId)
        {
            
            return cart.GetbyUserId(userId); 
        }

        [System.Web.Http.HttpPost]
        public List<Cart> PostCart(Cart newObj)
        {
            cart.AddItem(newObj);
            return cart.GetAllItems();
  
        }
        [HttpPut]
        public List<Cart> PutCart(int id, Cart updObj)
        {
            cart.UpdateItem(id, updObj);
            return cart.GetAllItems();
        }
        [HttpDelete]
        public List<Cart> DeleteCart(int id)
        {
            cart.DeleteItem(id);
            return cart.GetAllItems();
        }
    }
}
