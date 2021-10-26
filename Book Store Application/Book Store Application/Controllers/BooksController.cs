using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;
using System.IO;

namespace Book_Store_Application.Controllers
{
    public class BooksController : ApiController
    {
        List<Books> booklist = new List<Books>();
        Books bookObj = new Books();

        public List<Books> GetAllBooks()
        {

            try
            {                
                booklist = bookObj.GetAllBooks();
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }
            return booklist;
        }
        public List<Books> GetBookByCategory(int p_catID)
        {
            try
            {
                booklist = bookObj.GetBookByCategory(p_catID);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }
            return booklist;
        }
        public List<Books> GetBookById(int p_bookID)
        {
            try
            {
                booklist = bookObj.GetBookById(p_bookID);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }
            return booklist;
        }

        public List<Books> GetBookByTitleAuthor(string p_value)
        {
            try
            {
                booklist = bookObj.GetBookByTitleAuthor(p_value);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }
            return booklist;
        }
        [HttpPost]
        public List<Books> Post(Books newobj)
        {
            try
            {
                bookObj.addBook(newobj);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }
            
            return bookObj.GetAllBooks();
        }
        [HttpPut]
        public List<Books> Put(Books newbuk)
        {
            try
            {
                bookObj.updateBook(newbuk);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return bookObj.GetAllBooks();
        }
        [HttpDelete]
        public List<Books> Delete(int p_bookID)
        {
            try
            {
                bookObj.deleteBook(p_bookID);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return bookObj.GetAllBooks();
        }

    }
}
