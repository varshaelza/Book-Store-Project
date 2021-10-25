using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Store_Application.Models
{
    public class Purchases
    {
        #region Properties
        public int purchaseId { get; set; }
        public int bookId { get; set; }
        public int qty { get; set; }
        public int orderId { get; set; }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);
        SqlCommand cmd_getalldata = new SqlCommand("select * from Purchases");
        SqlCommand cmd_getbyorderid = new SqlCommand("select * from Purchases where orderId=@p_orderId");
        SqlCommand cmd_insertdata = new SqlCommand("insert into Purchases values(@p_bookId,@p_qty,@p_orderId)");
        SqlCommand cmd_updatedata = new SqlCommand("update Purchases set bookId=@p_bookId,qty=@p_qty,orderId=@p_orderId where purchaseId=@p_purchaseId");
        SqlCommand cmd_deletedata = new SqlCommand("delete from Purchases where purchaseId=@p_purchaseId");
        #endregion

        #region Constructors
        public Purchases()
        {

        }
        #endregion

        #region Methods
        public List<Purchases> GetAllPurchases()
        {
            List<Purchases> PurchasesList = new List<Purchases>();
            cmd_getalldata.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getalldata.ExecuteReader();
            while (_read.Read())
            {
                PurchasesList.Add(new Purchases() { purchaseId = Convert.ToInt32(_read[0]), bookId = Convert.ToInt32(_read[1]), qty = Convert.ToInt32(_read[2]), orderId = Convert.ToInt32(_read[3]) });
            }
            _read.Close();
            con.Close();
            if (PurchasesList.Count == 0)
            {
                throw new Exception("Purchases table does not contain any entries");
            }
            return PurchasesList;
        }

        public List<Purchases> GetPurchasebyOrderId(int p_orderId)
        {
            List<Purchases> PurchasesList = new List<Purchases>();
            cmd_getbyorderid.Parameters.AddWithValue("@p_orderId", p_orderId);
            cmd_getbyorderid.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getbyorderid.ExecuteReader();
            while (_read.Read())
            {
                PurchasesList.Add(new Purchases() { purchaseId = Convert.ToInt32(_read[0]), bookId = Convert.ToInt32(_read[1]), qty = Convert.ToInt32(_read[2]), orderId = Convert.ToInt32(_read[3]) });
            }
            _read.Close();
            con.Close();
            if (PurchasesList.Count == 0)
            {
                throw new Exception("Record orderId=" + p_orderId + " not found in Purchases table");
            }
            return PurchasesList;
        }

        public int AddPurchase(Purchases purchaseObj)
        {
            cmd_insertdata.Connection = con;
            cmd_insertdata.Parameters.AddWithValue("@p_bookId", purchaseObj.bookId);
            cmd_insertdata.Parameters.AddWithValue("@p_qty", purchaseObj.qty);
            cmd_insertdata.Parameters.AddWithValue("@p_orderId", purchaseObj.orderId);
            con.Open();
            int result = 0;
            try
            {
                result = cmd_insertdata.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                throw new Exception("Could not add entry into Purchases table");
            }
            if (result == 0)
            {
                throw new Exception("Could not add entry into Purchases table");
            }
            con.Close();
            return result;
        }

        public int UpdatePurchase(Purchases purchaseObj)
        {
            cmd_updatedata.Connection = con;
            cmd_updatedata.Parameters.AddWithValue("@p_purchaseId", purchaseObj.purchaseId);
            cmd_updatedata.Parameters.AddWithValue("@p_bookId", purchaseObj.bookId);
            cmd_updatedata.Parameters.AddWithValue("@p_qty", purchaseObj.qty);
            cmd_updatedata.Parameters.AddWithValue("@p_orderId", purchaseObj.orderId);
            con.Open();
            int result = cmd_updatedata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not update record purchaseId=" + purchaseObj.purchaseId + " in Purchases table");
            }
            return result;


        }
        public int DeletePurchase(int p_purchaseId)
        {
            cmd_deletedata.Connection = con;
            cmd_deletedata.Parameters.AddWithValue("@p_purchaseId", p_purchaseId);
            con.Open();
            int result = cmd_deletedata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not delete record purchaseId=" + p_purchaseId + " in Purchases table");
            }
            return result;
        }
        #endregion

    }
}
