using BookApp.Dal.Entities;
using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Bll.Repositories.Books
{
    public interface IBookRepository
    {
        Task<IReadOnlyCollection<Book>> GetBooks();
        Task<Book> GetBookById(Guid bookId);
        Task AddBook(BookEntity book);
        Task UpdateBook(BookEntity book);
        Task DeleteBook(Guid bookId);
    }
}
