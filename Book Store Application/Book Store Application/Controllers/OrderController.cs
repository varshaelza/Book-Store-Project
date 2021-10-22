using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Project.Models;
namespace Book_Store_Project.Controllers
{
    
    public class OrderController : ApiController
    {
        Orders ord = new Orders();
        [HttpGet]        
        public List<Orders> GetOrders()
        {
            return ord.GetAllOrders();
        }

        [HttpGet]
        public List<Orders> GetByUserId(int userId)
        {

            return ord.GetAllOrdersById(userId);
        }
        [HttpPost]
        public List<Orders> PostOrder(Orders newObj)
        {
            ord.AddOrder(newObj);
            return ord.GetAllOrders();

        }
    }
}
