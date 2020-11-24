using BookApp.Bll.Mappers.Reservations;
using BookApp.Dal;
using BookApp.Dto.Entities;
using BookApp.Dto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Bll.Repositories.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookAppDbContext _context;
        private readonly IReservationMapper _reservationMapper;

        public ReservationRepository(BookAppDbContext context, IReservationMapper reservationMapper)
        {
            _context = context;
            _reservationMapper = reservationMapper;
        }        

        public async Task Add(ReservationEntity reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Reservation>> GetReservationsByBookId(Guid bookId)
        {
            return await _context.Reservations
                .Where(x => x.BookId == bookId)
                .Include(x => x.User)
                .Select(x => _reservationMapper.Map(x))
                .ToListAsync();
        }

    }
}
