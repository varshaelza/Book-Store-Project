using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace Book_Store_Application.Models
{
    public class Books
    {
        public int bookId { get; set; }
        public int categoryId { get; set; }
        public string title { get; set; }
        public int ISBN { get; set; }
        public int year { get; set; }
        public double bookPrice { get; set; }
        public string bookDescription { get; set; }
        public int bookPosition { get; set; }
        public bool bookStatus { get; set; }
        public string bookImage { get; set; }
        public string author { get; set; }
        public int availableQty { get; set; }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);
        SqlCommand cmd_getAllBooks = new SqlCommand("select * from Books");
        SqlCommand cmd_getBookByCategory = new SqlCommand("select * from Books where categoryId=@catid");
        SqlCommand cmd_getBookById = new SqlCommand("select * from Books where bookId=@bookId");
        SqlCommand cmd_getBookByTitleAuthor = new SqlCommand("select * from Books where title = @p_value or author=@p_value");
        SqlCommand cmd_addBook = new SqlCommand("insert into Books values(@catid,@title,@isbn,@year,@bookprice,@bookdesc,@bookpos,@bookstatus,@bookimage,@author,@availableQty)"); 
        SqlCommand cmd_updateBook = new SqlCommand("update Books set bookPrice=@bookprice,bookPosition=@bookPos,bookStatus=@bookstatus,bookDescription=@bookdesc,Author=@author,availableQty=@availableQty,bookImage=@bookimage where bookID=@bookId");
        SqlCommand cmd_deleteBook = new SqlCommand("delete from Books where bookId=@bookid");

        List<Books> bookList = new List<Books>();
        List<Books> bookcatlist = new List<Books>();
        List<Books> booktitleauthorlist = new List<Books>();
        List<Books> bookidlist = new List<Books>();

        public List<Books> GetAllBooks()
        {
            cmd_getAllBooks.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllBooks.ExecuteReader(); //start reading the data
            while (_read.Read())
            {
                bookList.Add(new Books()
                {
                    bookId = Convert.ToInt32(_read[0]),
                    categoryId = Convert.ToInt32(_read[1]),
                    title = _read[2].ToString(),
                    ISBN = Convert.ToInt32(_read[3]),
                    year = Convert.ToInt32(_read[4]),
                    bookPrice = Convert.ToDouble(_read[5]),
                    bookDescription = _read[6].ToString(),
                    bookPosition = Convert.ToInt32(_read[7]),
                    bookStatus = Convert.ToBoolean(_read[8]),
                    bookImage = _read[9].ToString(),
                    author = _read[10].ToString(),
                    availableQty=Convert.ToInt32(_read[11])
                    

                });
            }
            _read.Close();
            con.Close();
            if (bookList.Count==0)
            {
                throw new Exception("Books table does not contain any entries");

            }
            return bookList;
        }

        public List<Books> GetBookByCategory(int p_catID)
        {
            cmd_getBookByCategory.Connection = con;
            cmd_getBookByCategory.Parameters.AddWithValue("@catid", p_catID);
            SqlDataReader _readBook;
            con.Open();
            _readBook = cmd_getBookByCategory.ExecuteReader();            
            while (_readBook.Read())
            {           

               bookcatlist.Add(new Books()
               {
                bookId= Convert.ToInt32(_readBook[0]),
                categoryId = Convert.ToInt32(_readBook[1]),
                title = _readBook[2].ToString(),
                ISBN = Convert.ToInt32(_readBook[3]),
                year = Convert.ToInt32(_readBook[4]),
                bookPrice= Convert.ToDouble(_readBook[5]),
                bookDescription= _readBook[6].ToString(),
                bookPosition=Convert.ToInt32(_readBook[7]),
                bookStatus = Convert.ToBoolean(_readBook[8]),
                bookImage=_readBook[9].ToString(),
                author = _readBook[10].ToString(),
                availableQty = Convert.ToInt32(_readBook[11])
                   
               });
            }
            _readBook.Close();
            con.Close();
            if (bookcatlist.Count == 0)
            {
                throw new Exception("Record categoryId = " + p_catID + " not found in Books table");

            }
            return bookcatlist;
        }

        public List<Books> GetBookById(int p_bookID)
        {
            cmd_getBookById.Connection = con;
            cmd_getBookById.Parameters.AddWithValue("@bookId", p_bookID);
            SqlDataReader _readBook;
            con.Open();
            _readBook = cmd_getBookById.ExecuteReader();
            while (_readBook.Read())
            {

                bookidlist.Add(new Books()
                {
                    bookId = Convert.ToInt32(_readBook[0]),
                    categoryId = Convert.ToInt32(_readBook[1]),
                    title = _readBook[2].ToString(),
                    ISBN = Convert.ToInt32(_readBook[3]),
                    year = Convert.ToInt32(_readBook[4]),
                    bookPrice = Convert.ToDouble(_readBook[5]),
                    bookDescription = _readBook[6].ToString(),
                    bookPosition = Convert.ToInt32(_readBook[7]),
                    bookStatus = Convert.ToBoolean(_readBook[8]),
                    bookImage = _readBook[9].ToString(),
                    author = _readBook[10].ToString(),
                    availableQty = Convert.ToInt32(_readBook[11])

                });
            }
            _readBook.Close();
            con.Close();
            if (bookidlist.Count == 0)
            {
                throw new Exception("Record bookId = " + p_bookID + " not found in Books table");

            }
            return bookidlist;
        }

        public List<Books> GetBookByTitleAuthor(string p_value)
        {
            cmd_getBookByTitleAuthor.Connection = con;
            cmd_getBookByTitleAuthor.Parameters.AddWithValue("@p_value", p_value);
            SqlDataReader _readBook;
            con.Open();
            _readBook = cmd_getBookByTitleAuthor.ExecuteReader();
            while (_readBook.Read())
            {

                booktitleauthorlist.Add(new Books()
                {
                    bookId = Convert.ToInt32(_readBook[0]),
                    categoryId = Convert.ToInt32(_readBook[1]),
                    title = _readBook[2].ToString(),
                    ISBN = Convert.ToInt32(_readBook[3]),
                    year = Convert.ToInt32(_readBook[4]),
                    bookPrice = Convert.ToDouble(_readBook[5]),
                    bookDescription = _readBook[6].ToString(),
                    bookPosition = Convert.ToInt32(_readBook[7]),
                    bookStatus = Convert.ToBoolean(_readBook[8]),
                    bookImage = _readBook[9].ToString(),
                    author = _readBook[10].ToString(),
                    availableQty = Convert.ToInt32(_readBook[11])
                    
                });
            }
            _readBook.Close();
            con.Close();
            if (booktitleauthorlist.Count == 0)
            {
                throw new Exception("Record title/author = " + p_value + " not found in Books table");

            }
            return booktitleauthorlist;
        }

        public int addBook(Books newbook)
        {
            cmd_addBook.Connection = con;
            cmd_addBook.Parameters.AddWithValue("@catid", newbook.categoryId);
            cmd_addBook.Parameters.AddWithValue("@title", newbook.title);
            cmd_addBook.Parameters.AddWithValue("@isbn", newbook.ISBN);
            cmd_addBook.Parameters.AddWithValue("@year", newbook.year);
            cmd_addBook.Parameters.AddWithValue("@bookprice", newbook.bookPrice);
            cmd_addBook.Parameters.AddWithValue("@bookdesc", newbook.bookDescription);
            cmd_addBook.Parameters.AddWithValue("@bookpos", newbook.bookPosition);
            cmd_addBook.Parameters.AddWithValue("@bookstatus", newbook.bookStatus);
            cmd_addBook.Parameters.AddWithValue("@bookimage", newbook.bookImage);
            cmd_addBook.Parameters.AddWithValue("@author", newbook.author);
            cmd_addBook.Parameters.AddWithValue("@availableQty", newbook.availableQty);
            int result = 0;

            con.Open();
            try {
                result = cmd_addBook.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                con.Close();
                throw new Exception("Could not add entry into Books table");
            }            
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not add entry into Books table");
            }
            return result;

        }

        public int updateBook(Books newbk)
        {
            cmd_updateBook.Connection = con;
            cmd_updateBook.Parameters.AddWithValue("@bookprice", newbk.bookPrice);
            cmd_updateBook.Parameters.AddWithValue("@bookpos", newbk.bookPosition);
            cmd_updateBook.Parameters.AddWithValue("@bookstatus", newbk.bookStatus);
            cmd_updateBook.Parameters.AddWithValue("@bookimage", newbk.bookImage);
            cmd_updateBook.Parameters.AddWithValue("@bookdesc", newbk.bookDescription);
            cmd_updateBook.Parameters.AddWithValue("@author", newbk.author);
            cmd_updateBook.Parameters.AddWithValue("@availableQty", newbk.availableQty);
            cmd_updateBook.Parameters.AddWithValue("@bookID", newbk.bookId);
            int result = 0;

            con.Open();
            try
            {
                result = cmd_updateBook.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception("Could not update record bookId = " + newbk.bookId + " in Books table");
            }
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not update record bookId = " + newbk.bookId + " in Books table");
            }
            return result;
        }

        public int deleteBook(int p_bookID)
        {
            cmd_deleteBook.Connection = con;
            cmd_deleteBook.Parameters.AddWithValue("@bookid", p_bookID);
            int result = 0;

            con.Open();
            try
            {
                result = cmd_deleteBook.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception("Could not delete record bookId = " + p_bookID + " in Books table");
            }
            con.Close();
            if (result == 0)
            {
                throw new Exception("Could not delete record bookId = " + p_bookID + " in Books table");
            }
            return result;

        }

    }
}
