using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Book_Store_Project.Models;
namespace Book_Store_Project.Controllers
{
    public class CategoryController : ApiController
    {
        Category cat = new Category();

        [HttpGet]
        public List<Category> GetCategory()
        {

            List<Category> catList = new List<Category>();
            try
            {
                Category cat = new Category();
                catList = cat.GetAllCategory();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }

            return catList;
        }


        [HttpPost]
        public List<Category> PostCategory(Category newObj)
        {
            Category cat = new Category();
            try
            {
                cat.AddCategory(newObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }

            return cat.GetAllCategory();
        }

        [HttpPut]
        public List<Category> PutCategory(int id, Category updObj)
        {
            Category cat = new Category();
            try
            {
                cat.UpdateCategory(id, updObj);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return cat.GetAllCategory();
        }

        [HttpPut]
        public List<Category> PutCategory(int id, int pos)
        {
            Category cat = new Category();
            try
            {
                cat.UpdateCategorybyPos(id, pos);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
            return cat.GetAllCategory();
        }

        [HttpDelete]
        public List<Category> DeleteCategory(int id)
        {
            Category cat = new Category();
            try
            {
                cat.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }

            return cat.GetAllCategory();
        }
    }
}
