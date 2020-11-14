using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dto.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
