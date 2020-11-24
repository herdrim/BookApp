using BookApp.Dto.Entities;
using BookApp.Dto.Models;

namespace BookApp.Bll.Mappers.Books
{
    public interface IBookMapper
    {
        Book Map(BookEntity book);
        BookEntity Map(Book book);
    }
}
