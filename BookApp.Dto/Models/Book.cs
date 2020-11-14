using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dto.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
