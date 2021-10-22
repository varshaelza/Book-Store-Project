using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Store_Application.Models
{
    public class WishList
    {
        #region Properties
        public int wishId { get; set; }
        public int bookId { get; set; }
        public int userId { get; set; }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);
        SqlCommand cmd_getalldata = new SqlCommand("select * from WishList");
        SqlCommand cmd_getdatabyuserid = new SqlCommand("select * from WishList where userId=@p_userId");
        SqlCommand cmd_insertdata = new SqlCommand("insert into WishList values(@p_bookId,@p_userId)");
        SqlCommand cmd_updatedata = new SqlCommand("update WishList set bookId=@p_bookId,userId=@p_userId where wishId=@p_wishId");
        SqlCommand cmd_deletedata = new SqlCommand("delete from WishList where wishId=@p_wishId");
        #endregion

        #region Constructor
        public WishList()
        {
            
        }
        #endregion

        #region Methods
        public List<WishList> GetAllWishList()
        {
            List<WishList> WishesList = new List<WishList>();
            cmd_getalldata.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getalldata.ExecuteReader();
            while (_read.Read())
            {
                WishesList.Add(new WishList() { wishId = Convert.ToInt32(_read[0]), bookId = Convert.ToInt32(_read[1]), userId = Convert.ToInt32(_read[2]) });
            }
            _read.Close();
            con.Close();
            return WishesList;
        }

        public List<WishList> GetbyUserId(int p_userId)
        {
            List<WishList> WishesList = new List<WishList>();
            cmd_getdatabyuserid.Parameters.AddWithValue("@p_userId", p_userId);
            cmd_getdatabyuserid.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getdatabyuserid.ExecuteReader();
            while (_read.Read())
            {
                WishesList.Add(new WishList() { wishId = Convert.ToInt32(_read[0]), bookId = Convert.ToInt32(_read[1]), userId = Convert.ToInt32(_read[2]) });
            }
            _read.Close();
            con.Close();
            return WishesList;
        }
        public int AddWishList(WishList wishObj)
        {
            cmd_insertdata.Connection = con;
            cmd_insertdata.Parameters.AddWithValue("@p_bookId", wishObj.bookId);
            cmd_insertdata.Parameters.AddWithValue("@p_userId", wishObj.userId);
            con.Open();
            int result = cmd_insertdata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            return result;
        }

        public int UpdateWishList(WishList wishObj)
        {
            cmd_updatedata.Connection = con;
            cmd_updatedata.Parameters.AddWithValue("@p_wishId", wishObj.wishId);
            cmd_updatedata.Parameters.AddWithValue("@p_bookId", wishObj.bookId);
            cmd_updatedata.Parameters.AddWithValue("@p_userId", wishObj.userId);
            con.Open();
            int result = cmd_updatedata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            return result;


        }
        public int DeleteWishList(int p_wishId)
        {
            cmd_deletedata.Connection = con;
            cmd_deletedata.Parameters.AddWithValue("@p_wishId", p_wishId);
            con.Open();
            int result = cmd_deletedata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            return result;
        }


        #endregion

}
}