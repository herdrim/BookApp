using BookApp.Bll.Mappers.Books;
using BookApp.Dal;
using BookApp.Dto.Entities;
using BookApp.Dto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Bll.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly BookAppDbContext _context;
        private readonly IBookMapper _bookMapper;

        public BookRepository(BookAppDbContext context, IBookMapper bookMapper)
        {
            _context = context;
            _bookMapper = bookMapper;
        }

        public async Task<IReadOnlyCollection<Book>> GetBooks()
        {

            return await _context.Books.Select(x => _bookMapper.Map(x)).ToListAsync();
        }

        public async Task<Book> GetBookById(Guid bookId)
        {

            return _bookMapper.Map(await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId));
        }

        public async Task AddBook(BookEntity book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(BookEntity book)
        {
            _context.Books.Update(book);            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Guid bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
