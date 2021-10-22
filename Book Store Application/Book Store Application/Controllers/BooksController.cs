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

        public List<Books> GetBookByTitle(string p_title)
        {
            return bookObj.GetBookByTitle(p_title);
        }
        public List<Books> GetBookByAuthor(string p_author)
        {
            return bookObj.GetBookByAuthor(p_author);
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
