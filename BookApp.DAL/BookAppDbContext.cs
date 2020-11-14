using System;
using System.Collections.Generic;
using System.Text;
using BookApp.Dal.Configurations;
using BookApp.Dal.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Dal
{
    public class BookAppDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }


        public BookAppDbContext(DbContextOptions<BookAppDbContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new BookEntityConfiguration());
            builder.ApplyConfiguration(new ReservationEntityConfiguration());
        }
    }
}
