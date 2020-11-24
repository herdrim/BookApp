using BookApp.Dto.Entities;
using BookApp.Dto.Models;

namespace BookApp.Bll.Mappers.Reservations
{
    public class ReservationMapper : IReservationMapper
    {
        public Reservation Map(ReservationEntity reservation)
        {
            return new Reservation
            {
                Id = reservation.Id,
                ReservationDate = reservation.ReservationDate,
                User = new User
                {
                   Id = reservation.User?.Id,
                   Name = reservation.User?.UserName
                }
            };
        }
    }
}
