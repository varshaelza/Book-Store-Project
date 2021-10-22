using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;

namespace Book_Store_Application.Controllers
{
    public class PurchasesController : ApiController
    {
        public List<Purchases> GetAllPurchases()
        {
            Purchases purchaseObj = new Purchases();
            return purchaseObj.GetAllPurchases();
        }

        [HttpGet]
        public List<Purchases> GetPurchaseByOrderId(int p_orderId)
        {
            Purchases purchaseObj = new Purchases();
            return purchaseObj.GetPurchasebyOrderId(p_orderId);
        }

        [HttpPost]
        public List<Purchases> PostPurchase(Purchases p_purchaseObj)
        {
            Purchases purchaseObj = new Purchases();
            purchaseObj.AddPurchase(p_purchaseObj);
            return purchaseObj.GetAllPurchases();
        }

        [HttpPut]
        public List<Purchases> PutPurchase(Purchases p_purchaseObj)
        {
            Purchases purchaseObj = new Purchases();
            purchaseObj.UpdatePurchase(p_purchaseObj);
            return purchaseObj.GetAllPurchases();
        }

        [HttpDelete]
        public List<Purchases> DeletePurchase(Purchases p_purchaseObj)
        {
            Purchases purchaseObj = new Purchases();
            purchaseObj.DeletePurchase(p_purchaseObj.purchaseId);
            return purchaseObj.GetAllPurchases();
        }
    }
}
