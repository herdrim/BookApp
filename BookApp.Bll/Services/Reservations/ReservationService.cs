using BookApp.Bll.Repositories.Reservations;
using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Bll.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IReadOnlyCollection<Reservation>> GetAllReservationsByBookId(Guid bookId)
        {
            return await _reservationRepository.GetReservationsByBookId(bookId);
        }
    }
}
