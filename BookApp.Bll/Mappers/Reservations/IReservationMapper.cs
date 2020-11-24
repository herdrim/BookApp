using BookApp.Dto.Entities;
using BookApp.Dto.Models;

namespace BookApp.Bll.Mappers.Reservations
{
    public interface IReservationMapper
    {
        Reservation Map(ReservationEntity reservation);
    }
}
