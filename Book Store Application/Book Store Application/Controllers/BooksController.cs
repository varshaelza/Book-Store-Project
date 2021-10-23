using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;

namespace Book_Store_Application.Controllers
{
    public class BooksController : ApiController
    {
        Books bookObj = new Books();

        public List<Books> GetAllBooks()
        {
            return bookObj.GetAllBooks();
        }
        public List<Books> GetBookByCategory(int p_catID)
        {
            return bookObj.GetBookByCategory(p_catID);
        }

        public List<Books> GetBookByTitleAuthor(string p_value)
        {
            return bookObj.GetBookByTitleAuthor(p_value);
        }
        [HttpPost]
        public List<Books> Post(Books newobj)
        {
            bookObj.addBook(newobj);
            return bookObj.GetAllBooks();
        }
        [HttpPut]
        public List<Books> Put(Books newbuk)
        {
            bookObj.updateBook(newbuk);
            return bookObj.GetAllBooks();
        }
        [HttpDelete]
        public List<Books> Delete(int p_bookID)
        {
            bookObj.deleteBook(p_bookID);
            return bookObj.GetAllBooks();
        }

    }
}
