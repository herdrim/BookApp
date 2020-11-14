using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dal.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public ICollection<ReservationEntity> Reservations { get; set; }
    }
}
