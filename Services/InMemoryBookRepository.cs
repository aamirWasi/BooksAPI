using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;

namespace BooksAPI.Services
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly BooksAPIContext _booksAPIContext;

        public InMemoryBookRepository(BooksAPIContext booksAPIContext)
        {
            _booksAPIContext = booksAPIContext;
        }
        public Book AddBooks(Book book)
        {
            var addedBooks = _booksAPIContext.Add(book);
            SaveContextChanges(_booksAPIContext);
            book.Id = addedBooks.Entity.Id;
            return book;
        }

        private void SaveContextChanges(BooksAPIContext _booksAPIContext)
        {
            _booksAPIContext.SaveChanges();
        }

        public void Delete(Book book)
        {
            _booksAPIContext.Remove(book);
            SaveContextChanges(_booksAPIContext);
        }

        public IEnumerable<Book> GetAll()
        {
            return _booksAPIContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _booksAPIContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Book book)
        {
            var bookToUpdate = GetById(book.Id);
            bookToUpdate.Author = book.Author;
            bookToUpdate.Name = book.Name;
            bookToUpdate.PublisedDate = book.PublisedDate;

            _booksAPIContext.Update(bookToUpdate);
            SaveContextChanges(_booksAPIContext);
        }
    }
}
