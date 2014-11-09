using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class BooksController : ApiController
    {
        public static List<Book> book;
        public BooksController()
        {  
        }
        // GET api/book
        public List<Book> Get()
        {
            GetBooks();
            return book;
        }

        // GET api/book/5
        public  IEnumerable<Book> Get(int id)
        {
            GetBooks();
            return book.Where(e => e.Id == id);
        }


        private List<Book> GetBooks()
        {
           return  book = new List<Book>()
            {
               new Book() { Author ="Lalithambigai", Id=1, ISBN="333332244",Name="Poems",Price=30.0},
               new Book() { Author ="Ramya", Id=2, ISBN="3333",Name="ShortStories",Price=80.0},
               new Book() { Author ="Kundai", Id=3, ISBN="333332244",Name="MysteryStories",Price=30.0},
            };
        }
        // POST api/default1
        public bool Post(Book addbook)
        {
            GetBooks();
            book.Add(new Book()
            {
                Author = addbook.Author,
                Id = addbook.Id,
               ISBN = addbook.ISBN,
               Name = addbook.Name,
               Price = addbook.Price
            });
            return true;

        }

        // PUT api/default1/5
        public void Put(Book bk)
        {
            int Id = bk.Id;
            GetBooks();
            Book bking = book.Where(e => e.Id == Id).First<Book>();

            book.Remove(bking);
            bking.Name = bk.Name;
            bking.Author = bk.Author;
            bking.Price = bk.Price;
            bking.ISBN = bk.ISBN;
            bking.Id = bk.Id;
            book.Add(bking);

        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
            GetBooks();
            Book bk = book.Where(e => e.Id == id).First<Book>();
            book.Remove(bk);
        }

    }
}
