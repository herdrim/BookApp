using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Bll.Services.Reservations
{
    public interface IReservationService
    {
        Task<IReadOnlyCollection<Reservation>> GetAllReservationsByBookId(Guid bookId);
    }
}
