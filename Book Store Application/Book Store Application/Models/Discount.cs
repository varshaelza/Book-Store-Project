using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Store_Application.Models
{
    public class Discount
    {
        #region Properties
        public int couponId { get; set; }
        public string couponCode { get; set; }
        public double minPurchase { get; set; }
        public double disPercent { get; set; }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);
        SqlCommand cmd_getalldata = new SqlCommand("select * from Discount");
        SqlCommand cmd_getbyminpurchase = new SqlCommand("select * from Discount where minPurchase< @p_totPurchase");
        SqlCommand cmd_getbycouponcode = new SqlCommand("select * from Discount where couponCode=@p_couponCode");
        SqlCommand cmd_insertdata = new SqlCommand("insert into Discount values(@p_couponCode,@p_minPurchase,@p_disPercent)");
        SqlCommand cmd_updatedata = new SqlCommand("update Discount set couponCode=@p_couponCode,minPurchase=@p_minPurchase,disPercent=@p_disPercent where couponId=@p_couponId");
        SqlCommand cmd_deletedata = new SqlCommand("delete from Discount where couponId=@p_couponId");
        #endregion

        #region Constructors
        public Discount()
        {

        }
        #endregion

        #region Methods
        public List<Discount> GetAllDiscount()
        {
            List<Discount> DisList = new List<Discount>();
            cmd_getalldata.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getalldata.ExecuteReader();
            while (_read.Read())
            {
                DisList.Add(new Discount() { couponId = Convert.ToInt32(_read[0]), couponCode = Convert.ToString(_read[1]), minPurchase = Convert.ToDouble(_read[2]), disPercent = Convert.ToDouble(_read[3]) });
            }
            _read.Close();
            con.Close(); 
            if(DisList.Count==0)
            {
                throw new Exception("Discount table does not contain any entries");
            }
            return DisList;
        }

        public List<Discount> GetbyMinPurchase(double p_totPurchase)
        {
            List<Discount> DisList = new List<Discount>();
            cmd_getbyminpurchase.Parameters.AddWithValue("@p_totPurchase", p_totPurchase);
            cmd_getbyminpurchase.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getbyminpurchase.ExecuteReader();
            while (_read.Read())
            {
                DisList.Add(new Discount() { couponId = Convert.ToInt32(_read[0]), couponCode = Convert.ToString(_read[1]), minPurchase = Convert.ToDouble(_read[2]), disPercent = Convert.ToDouble(_read[3]) });
            }
            _read.Close();
            con.Close();
            if (DisList.Count == 0)
            {
                throw new Exception("Record minPurchase<"+p_totPurchase+" not found in Discount table");
            }
            return DisList;
        }


        public List<Discount> GetbyCouponCode(string p_couponCode)
        {
            List<Discount> DisList = new List<Discount>();
            cmd_getbycouponcode.Parameters.AddWithValue("@p_couponCode", p_couponCode);
            cmd_getbycouponcode.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getbycouponcode.ExecuteReader();
            while (_read.Read())
            {
                DisList.Add(new Discount() { couponId = Convert.ToInt32(_read[0]), couponCode = Convert.ToString(_read[1]), minPurchase = Convert.ToDouble(_read[2]), disPercent = Convert.ToDouble(_read[3]) });
            }
            _read.Close();
            con.Close();
            if (DisList.Count == 0)
            {
                throw new Exception("Record couponCode="+p_couponCode+" not found in Discount table");
            }
            return DisList;
        }

        public int AddDiscount(Discount disObj)
        {
            cmd_insertdata.Connection = con;
            cmd_insertdata.Parameters.AddWithValue("@p_couponCode", disObj.couponCode);
            cmd_insertdata.Parameters.AddWithValue("@p_minPurchase", disObj.minPurchase);
            cmd_insertdata.Parameters.AddWithValue("@p_disPercent",disObj.disPercent);
            con.Open();
            int result = 0;
            try
            {
                result = cmd_insertdata.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                throw new Exception("Could not add entry into Discount table");
            }
            if(result==0)
            {
                throw new Exception("Could not add entry into Discount table" );
            }
            con.Close();
            return result;
        }

        public int UpdateDiscount(Discount disObj)
        {
            cmd_updatedata.Connection = con;
            cmd_updatedata.Parameters.AddWithValue("@p_couponId", disObj.couponId);
            cmd_updatedata.Parameters.AddWithValue("@p_couponCode", disObj.couponCode);
            cmd_updatedata.Parameters.AddWithValue("@p_minPurchase", disObj.minPurchase);
            cmd_updatedata.Parameters.AddWithValue("@p_disPercent", disObj.disPercent);
            con.Open();
            int result = cmd_updatedata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not update record couponId="+disObj.couponId+" in Discount table");
            }
            return result;


        }
        public int DeleteDiscount(int p_couponId)
        {
            cmd_deletedata.Connection = con;
            cmd_deletedata.Parameters.AddWithValue("@p_couponId", p_couponId);
            con.Open();
            int result = cmd_deletedata.ExecuteNonQuery();//returns number of lines affected
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not delete record couponId=" +p_couponId + " in Discount table");
            }
            return result;
        }

      
        #endregion
    }
}
