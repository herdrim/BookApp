using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dal.Entities
{
    public class ReservationEntity
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
    }
}
