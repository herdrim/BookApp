using BookApp.Dal.Entities;
using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Bll.Repositories.Reservations
{
    public interface IReservationRepository
    {
        Task Add(ReservationEntity reservation);
        Task<IReadOnlyCollection<Reservation>> GetReservationsByBookId(Guid bookId);
    }
}
