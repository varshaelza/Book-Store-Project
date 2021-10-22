using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Store_Project.Models
{
    public class Cart
    {
        #region Properties
        public int cartId { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public int bookQty { get; set; }
        #endregion

        List<Cart> cartList = new List<Cart>();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);

        SqlCommand cmd_getAllItems = new SqlCommand("select * from Cart");
        SqlCommand cmd_getItemByUserId = new SqlCommand("select * from Cart where userId = @userId");
        SqlCommand cmd_addItem = new SqlCommand("insert into Cart values(@userId, @bookId, @bookQty)");
        SqlCommand cmd_updateItem = new SqlCommand("update Cart set bookQty = @bookQty where cartId=@cartId");
        SqlCommand cmd_deleteItem = new SqlCommand("delete from Cart where cartId=@cartId");

        #region Methods
        public List<Cart> GetAllItems()
        {
            cmd_getAllItems.Connection = con; //my command is going to use connection
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllItems.ExecuteReader(); //start reading
            while (_read.Read())
            {
                cartList.Add(new Cart()
                {
                    cartId = Convert.ToInt32(_read[0]),
                    userId = Convert.ToInt32(_read[1]),
                    bookId = Convert.ToInt32(_read[2]),
                    bookQty = Convert.ToInt32(_read[3])
                });
            }
            _read.Close();
            con.Close();

            return cartList;
        }

        public List<Cart> GetbyUserId(int p_userId)
        {

            cmd_getItemByUserId.Parameters.AddWithValue("@userId", p_userId);
            cmd_getItemByUserId.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getItemByUserId.ExecuteReader();
            while (_read.Read())
            {
                cartList.Add(new Cart() 
                {
                    cartId = Convert.ToInt32(_read[0]),
                    userId = Convert.ToInt32(_read[1]),
                    bookId = Convert.ToInt32(_read[2]),
                    bookQty = Convert.ToInt32(_read[3])
                });
            }
            _read.Close();
            con.Close();
            return cartList;
        }

        public int AddItem(Cart cartObj)
        {
            cmd_addItem.Connection = con;
            cmd_addItem.Parameters.AddWithValue("@userId", cartObj.userId);
            cmd_addItem.Parameters.AddWithValue("@bookId", cartObj.bookId);
            cmd_addItem.Parameters.AddWithValue("@bookQty", cartObj.bookQty);



            con.Open();
            int result = cmd_addItem.ExecuteNonQuery();
            con.Close();
            return result;

        }

        public int UpdateItem(int id, Cart cartObj)
        {
            cmd_updateItem.Connection = con;
            cmd_updateItem.Parameters.AddWithValue("@bookQty", cartObj.bookQty);

            cmd_updateItem.Parameters.AddWithValue("@cartId", id);
            con.Open();
            int result = cmd_updateItem.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteItem(int cartId)
        {
            cmd_deleteItem.Connection = con;
            //cmd_deleteItem.Parameters.AddWithValue("@userId", id);
            //cmd_deleteItem.Parameters.AddWithValue("@bookId", bookId);
            cmd_deleteItem.Parameters.AddWithValue("@cartId", cartId);

            con.Open();
            int result = cmd_deleteItem.ExecuteNonQuery();
            con.Close();
            return result;
        }
        #endregion
    }
}
