using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Book_Store_Project.Models
{
    public class Orders
    {
        #region Properties
        public int orderId { get; set; }
        public int userId { get; set; }
        public int couponId { get; set; }
        public double totalAmt { get; set; }
        public DateTime dateTimeOrder { get; set; }
        #endregion

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);

        SqlCommand cmd_getAllOrders = new SqlCommand("select * from Orders");
        SqlCommand cmd_getAllOrdersByOrderId = new SqlCommand("select * from Orders where orderId=@orderId");
        SqlCommand cmd_getAllOrdersByUserId = new SqlCommand("select * from Orders where userId=@userId");
        SqlCommand cmd_addOrder = new SqlCommand("insert into Orders values(@userId, @couponId, @totalAmt, @dateTimeOrder)");


        #region Methods
        public List<Orders> GetAllOrders()
        {
            List<Orders> ordList = new List<Orders>();
            cmd_getAllOrders.Connection = con; //my command is going to use connection
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllOrders.ExecuteReader(); //start reading
            while (_read.Read())
            {
                ordList.Add(new Orders()
                {
                    orderId = Convert.ToInt32(_read[0]),
                    userId = Convert.ToInt32(_read[1]),
                    couponId = Convert.ToInt32(_read[2]),
                    totalAmt = Convert.ToDouble(_read[3]),
                    dateTimeOrder = Convert.ToDateTime(_read[4])
                });
            }
            _read.Close();
            con.Close();

            if (ordList.Count == 0)
            {
                throw new Exception("Orders table does not contain any entries");
            }
            return ordList;
        }

        public List<Orders> GetAllOrdersByOrderId(int id)
        {
            List<Orders> ordList = new List<Orders>();
            cmd_getAllOrdersByOrderId.Connection = con; //my command is going to use connection
            cmd_getAllOrdersByOrderId.Parameters.AddWithValue("@orderId", id);
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllOrdersByOrderId.ExecuteReader(); //start reading
            while (_read.Read())
            {
                ordList.Add(new Orders()
                {
                    orderId = Convert.ToInt32(_read[0]),
                    userId = Convert.ToInt32(_read[1]),
                    couponId = Convert.ToInt32(_read[2]),
                    totalAmt = Convert.ToDouble(_read[3]),
                    dateTimeOrder = Convert.ToDateTime(_read[4])
                });
            }
            _read.Close();
            con.Close();

            if (ordList.Count == 0)
            {
                throw new Exception("Record orderId = " + id + " not found in Orders table");
            }

            return ordList;
        }

        public List<Orders> GetAllOrdersById(int id)
        {
            List<Orders> ordList = new List<Orders>();
            cmd_getAllOrdersByUserId.Connection = con; //my command is going to use connection
            cmd_getAllOrdersByUserId.Parameters.AddWithValue("@userId", id);
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllOrdersByUserId.ExecuteReader(); //start reading
            while (_read.Read())
            {
                ordList.Add(new Orders()
                {
                    orderId = Convert.ToInt32(_read[0]),
                    userId = Convert.ToInt32(_read[1]),
                    couponId = Convert.ToInt32(_read[2]),
                    totalAmt = Convert.ToDouble(_read[3]),
                    dateTimeOrder = Convert.ToDateTime(_read[4])
                });
            }
            _read.Close();
            con.Close();

            if (ordList.Count == 0)
            {
                throw new Exception("Record userId = " + id + " not found in Orders table");
            }
            return ordList;
        }


        public int AddOrder(Orders orderObj)
        {
            cmd_addOrder.Connection = con;
            cmd_addOrder.Parameters.AddWithValue("@userId", orderObj.userId);
            cmd_addOrder.Parameters.AddWithValue("@couponId", orderObj.couponId);
            cmd_addOrder.Parameters.AddWithValue("@totalAmt", orderObj.totalAmt);
            cmd_addOrder.Parameters.AddWithValue("@dateTimeOrder", orderObj.dateTimeOrder);
            int result = 0;
            con.Open();
            try
            {
                result = cmd_addOrder.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception("Could not add entry into Orders table");
            }
            
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not add entry into Orders table");
            }
            
            return result;

        }
        #endregion
    }
}
