using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Project.Models;
namespace Book_Store_Project.Controllers
{
    public class CategoryController : ApiController
    {
        Category cat = new Category();

        [HttpGet]
        public List<Category> GetCategory()
        {
            return cat.GetAllCategory();
        }


        [System.Web.Http.HttpPost]
        public List<Category> PostCategory(Category newObj)
        {
            cat.AddCategory(newObj);
            return cat.GetAllCategory();
            //return 1;
        }
        [HttpPut]
        public List<Category> PutCategory(int id, Category updObj)
        {
            cat.UpdateCategory(id, updObj);
            return cat.GetAllCategory();
        }
        [HttpDelete]
        public List<Category> DeleteCategory(int id)
        {
            cat.DeleteCategory(id);
            return cat.GetAllCategory();
        }
    }
}
