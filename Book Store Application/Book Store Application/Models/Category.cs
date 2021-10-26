using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Store_Project.Models
{
    public class Category
    {
        #region Properties
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDesc { get; set; }
        public string categoryImg { get; set; }
        public bool categoryStatus { get; set; }
        public int categoryPosition { get; set; }
        public DateTime categoryCreatedAt { get; set; }
        #endregion

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);

        SqlCommand cmd_getAllData = new SqlCommand("select * from Category where categoryStatus = 1 order by categoryPosition");
        SqlCommand cmd_addCategory = new SqlCommand("insert into Category values(@categoryName, @categoryDesc, @categoryImg, @categoryStatus, @categoryPosition,@categoryCreatedAt)");
        SqlCommand cmd_updateCategory = new SqlCommand("update Category set categoryName = @categoryName, categoryDesc = @categoryDesc, categoryImg = @categoryImg, categoryStatus = @categoryStatus, categoryPosition=@categoryPosition, categoryCreatedAt=@categoryCreatedAt where categoryId = @categoryId");
        SqlCommand cmd_deleteCategory = new SqlCommand("delete from Category where categoryId = @categoryId");

        #region Methods
        public List<Category> GetAllCategory()
        {
            List<Category> catList = new List<Category>();
            cmd_getAllData.Connection = con; //my command is going to use connection
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllData.ExecuteReader(); 
            while (_read.Read())
            {
                catList.Add(new Category()
                {
                    categoryId = Convert.ToInt32(_read[0]),
                    categoryName = _read[1].ToString(),
                    categoryDesc = _read[2].ToString(),
                    categoryImg = _read[3].ToString(),
                    categoryStatus = Convert.ToBoolean(_read[4]),
                    categoryPosition = Convert.ToInt32(_read[5]),
                    categoryCreatedAt = Convert.ToDateTime(_read[6])
                });
            }
            _read.Close();
            con.Close();

            if (catList.Count == 0)
            {
                throw new Exception("Category table does not contain any entries");
            }
            return catList;
        }

        public int AddCategory(Category catObj)
        {
            cmd_addCategory.Connection = con;
            cmd_addCategory.Parameters.AddWithValue("@categoryName", catObj.categoryName);
            cmd_addCategory.Parameters.AddWithValue("@categoryDesc", catObj.categoryDesc);
            cmd_addCategory.Parameters.AddWithValue("@categoryImg", catObj.categoryImg);
            cmd_addCategory.Parameters.AddWithValue("@categoryStatus", catObj.categoryStatus);
            cmd_addCategory.Parameters.AddWithValue("@categoryPosition", catObj.categoryPosition);
            cmd_addCategory.Parameters.AddWithValue("@categoryCreatedAt", catObj.categoryCreatedAt);
            int result = 0;

            con.Open();
            try
            {
                result = cmd_addCategory.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                con.Close();
                throw new Exception("Could not add entry into Category table");
            }
            

            if (result == 0)
            {
                throw new Exception("Could not add entry into Category table");
            }
            con.Close();
            return result;

        }

        public int UpdateCategory(int id, Category catObj)
        {
            cmd_updateCategory.Connection = con;
            cmd_updateCategory.Parameters.AddWithValue("@categoryName", catObj.categoryName);
            cmd_updateCategory.Parameters.AddWithValue("@categoryDesc", catObj.categoryDesc);
            cmd_updateCategory.Parameters.AddWithValue("@categoryImg", catObj.categoryImg);
            cmd_updateCategory.Parameters.AddWithValue("@categoryStatus", catObj.categoryStatus);
            cmd_updateCategory.Parameters.AddWithValue("@categoryPosition", catObj.categoryPosition);
            cmd_updateCategory.Parameters.AddWithValue("@categoryCreatedAt", catObj.categoryCreatedAt);
            cmd_updateCategory.Parameters.AddWithValue("@categoryId", id);
            int result = 0;
            con.Open();

            try
            {
                result = cmd_updateCategory.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                con.Close();
                throw new Exception("Could not update record categoryId = " + id + " in Category table");
            }
            

            if (result == 0)
            {
                throw new Exception("Could not update record categoryId = " + id + " in Category table");
            }
            con.Close();
            return result;
        }

        public int DeleteCategory(int id)
        {
            cmd_deleteCategory.Connection = con;
            cmd_deleteCategory.Parameters.AddWithValue("@categoryId", id);
            con.Open();
            int result = cmd_deleteCategory.ExecuteNonQuery();
            con.Close();

            if (result == 0)
            {
                throw new Exception("Could not delete record categoryId = " + id + " in Category table");
            }
            return result;
        }
        #endregion
    }
}
