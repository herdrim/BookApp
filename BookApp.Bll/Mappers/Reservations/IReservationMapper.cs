using BookApp.Dal.Entities;
using BookApp.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Bll.Mappers.Reservations
{
    public interface IReservationMapper
    {
        Reservation Map(ReservationEntity reservation);
    }
}
