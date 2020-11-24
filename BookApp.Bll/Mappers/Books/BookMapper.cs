using BookApp.Dto.Entities;
using BookApp.Dto.Models;

namespace BookApp.Bll.Mappers.Books
{
    public class BookMapper : IBookMapper
    {
        public Book Map(BookEntity book)
        {
            return new Book
            {
                Id = book.Id,
                Author = book.Author,
                Description = book.Description,
                Name = book.Name,
                ReleaseDate = book.ReleaseDate
            };
        }

        public BookEntity Map(Book book)
        {
            return new BookEntity
            {
                Id = book.Id,
                Author = book.Author,
                Description = book.Description,
                Name = book.Name,
                ReleaseDate = book.ReleaseDate
            };
        }
    }
}
