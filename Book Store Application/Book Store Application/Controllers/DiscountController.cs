using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;

namespace Book_Store_Application.Controllers
{
    public class DiscountController : ApiController
    {
        public List<Discount> GetAllDiscount()
        {
            Discount disObj = new Discount();
            return (disObj.GetAllDiscount());
        }

        [HttpGet]
        public List<Discount> GetByMinPurchase(double p_totpurchase)
        {
            Discount disObj = new Discount();
            return (disObj.GetbyMinPurchase(p_totpurchase));
        }

        [HttpGet]
        public List<Discount> GetByCouponCode(string p_couponCode)
        {
            Discount disObj = new Discount();
            return (disObj.GetbyCouponCode(p_couponCode));
        }


        [System.Web.Http.HttpPost]
        public List<Discount> PostDiscount(Discount p_disObj)
        {
            Discount disObj = new Discount();
            disObj.AddDiscount(p_disObj);
            return disObj.GetAllDiscount();
            
        }

        [System.Web.Http.HttpPut]
        public List<Discount> PutDiscount(Discount p_disObj)
        {
            Discount disObj = new Discount();
            disObj.UpdateDiscount(p_disObj);
            return disObj.GetAllDiscount();

        }
        [System.Web.Http.HttpDelete]
        public List<Discount> DeleteDiscount(Discount p_disObj)
        {
            Discount disObj = new Discount();
            disObj.DeleteDiscount(p_disObj.couponId);
            return disObj.GetAllDiscount();

        }
    }

}
