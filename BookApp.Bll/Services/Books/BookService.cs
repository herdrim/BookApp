using BookApp.Bll.Mappers.Books;
using BookApp.Bll.Repositories.Books;
using BookApp.Bll.Repositories.Reservations;
using BookApp.Bll.Services.Users;
using BookApp.Dto.Entities;
using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApp.Bll.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookMapper _bookMapper;
        private readonly IUserService _userRepository;

        public BookService(
            IBookRepository bookRepository,
            IReservationRepository reservationRepository,
            IBookMapper bookMapper, 
            IUserService userRepository)
        {
            _bookRepository = bookRepository;
            _reservationRepository = reservationRepository;
            _bookMapper = bookMapper;
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<Book>> GetAllBooks()
        {
            return await _bookRepository.GetBooks();
        }

        public async Task<Book> GetBook(Guid bookId)
        {
            return await _bookRepository.GetBookById(bookId);
        }

        public async Task CreateBook(Book book)
        {
            var bookEntity = _bookMapper.Map(book);
            await _bookRepository.AddBook(bookEntity);
        }

        public async Task UpdateBook(Book book)
        {
            var existingBook = _bookMapper.Map(book);
            await _bookRepository.UpdateBook(existingBook);
        }

        public async Task DeleteBook(Guid bookId)
        {
            await _bookRepository.DeleteBook(bookId);
        }

        public async Task ReserveBook(Guid bookId, string userName)
        {
            var reservation = new ReservationEntity
            {
                ReservationDate = DateTime.Now,
                BookId = bookId,
                User = await _userRepository.GetUserEntity(userName)
            };

            await _reservationRepository.Add(reservation);         
        }
    }
}
