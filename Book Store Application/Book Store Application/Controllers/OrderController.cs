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
    
    public class OrderController : ApiController
    {
        

        [HttpGet]        
        public List<Orders> GetOrders()
        {
            List<Orders> ordList = new List<Orders>();
            try
            {
                Orders ord = new Orders();
                ordList = ord.GetAllOrders();
            }
            catch(Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return ordList;
        }

        [HttpGet]
        public List<Orders> GetByUserId(int userId)
        {
            List<Orders> ordList = new List<Orders>();
            try
            {
                Orders ord = new Orders();
                ordList = ord.GetAllOrdersById(userId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return ordList;

        }

        [HttpPost]
        public List<Orders> PostOrder(Orders newObj)
        {
            Orders ord = new Orders();
            try
            {
                ord.AddOrder(newObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return ord.GetAllOrders();

        }
    }
}
