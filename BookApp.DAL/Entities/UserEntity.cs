using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dal.Entities
{
    public class UserEntity : IdentityUser
    {
        public ICollection<ReservationEntity> Reservations { get; set; }
    }
}
