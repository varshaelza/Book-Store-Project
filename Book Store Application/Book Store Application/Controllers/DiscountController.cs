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
    public class DiscountController : ApiController
    {
        public List<Discount> GetAllDiscount()
        {
            List<Discount> DisList = new List<Discount>();
            try
            {
                Discount disObj = new Discount();
                DisList= disObj.GetAllDiscount();
            }
            catch(Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return DisList;
        }

        [HttpGet]
        public List<Discount> GetByMinPurchase(double p_totpurchase)
        {
            List<Discount> DisList = new List<Discount>();
            try
            {
                Discount disObj = new Discount();
                DisList = disObj.GetbyMinPurchase(p_totpurchase);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return DisList;
        }

        [HttpGet]
        public List<Discount> GetByCouponCode(string p_couponCode)
        {
            List<Discount> DisList = new List<Discount>();
            try
            {
                Discount disObj = new Discount();
                DisList = disObj.GetbyCouponCode(p_couponCode);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return DisList;

        }


        [System.Web.Http.HttpPost]
        public List<Discount> PostDiscount(Discount p_disObj)
        {
            List<Discount> DisList = new List<Discount>();
            Discount disObj = new Discount();
            try
            { 
                int rowsAffected = disObj.AddDiscount(p_disObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return disObj.GetAllDiscount();
            
        }

        [System.Web.Http.HttpPut]
        public List<Discount> PutDiscount(Discount p_disObj)
        {
            List<Discount> DisList = new List<Discount>();
            Discount disObj = new Discount();
            try
            {
                int rowsAffected = disObj.UpdateDiscount(p_disObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }

            return disObj.GetAllDiscount();

        }
        [System.Web.Http.HttpDelete]
        public List<Discount> DeleteDiscount(int p_couponId)
        {
            List<Discount> DisList = new List<Discount>();
            Discount disObj = new Discount();
            try
            {
                int rowsAffected = disObj.DeleteDiscount(p_couponId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }

            return disObj.GetAllDiscount();

        }
    }

}
