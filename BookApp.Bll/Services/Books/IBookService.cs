using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Bll.Services.Books
{
    public interface IBookService
    {
        Task<IReadOnlyCollection<Book>> GetAllBooks();
        Task<Book> GetBook(Guid bookId);
        Task CreateBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid bookId);
        Task ReserveBook(Guid bookId, string userName);
    }
}
