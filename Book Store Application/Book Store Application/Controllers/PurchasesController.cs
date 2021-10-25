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
    public class PurchasesController : ApiController
    {
        public List<Purchases> GetAllPurchases()
        {
            Purchases purchaseObj = new Purchases();
            List<Purchases> purchaseList = new List<Purchases>();
            try
            {
                purchaseList= purchaseObj.GetAllPurchases();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return purchaseList;
        }

        [HttpGet]
        public List<Purchases> GetPurchaseByOrderId(int p_orderId)
        {
            Purchases purchaseObj = new Purchases();
            List<Purchases> purchaseList = new List<Purchases>();
            try
            {
                purchaseList = purchaseObj.GetPurchasebyOrderId(p_orderId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return purchaseList;
        }

        [HttpPost]
        public List<Purchases> PostPurchase(Purchases p_purchaseObj)
        {
            Purchases purchaseObj = new Purchases();
            try
            {
                int rowsAffected = purchaseObj.AddPurchase(p_purchaseObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return purchaseObj.GetAllPurchases();
        }

        [HttpPut]
        public List<Purchases> PutPurchase(Purchases p_purchaseObj)
        {
            Purchases purchaseObj = new Purchases();
            try
            {
                int rowsAffected = purchaseObj.UpdatePurchase(p_purchaseObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return purchaseObj.GetAllPurchases();
        }

        [HttpDelete]
        public List<Purchases> DeletePurchase(int p_purchaseId)
        {
            Purchases purchaseObj = new Purchases();
            try
            {
                int rowsAffected = purchaseObj.DeletePurchase(p_purchaseId);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(ex.Message);
                sr.Close();
                fs.Close();
            }
            return purchaseObj.GetAllPurchases();
        }
    }
}
