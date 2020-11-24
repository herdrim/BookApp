using BookApp.Dto.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Dal.Configurations
{
    public class ReservationEntityConfiguration : IEntityTypeConfiguration<ReservationEntity>
    {
        public void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(p => p.Reservations)
                .HasForeignKey(p => p.UserId)
                .IsRequired(true);

            builder.HasOne(p => p.Book)
                .WithMany(p => p.Reservations)
                .HasForeignKey(p => p.BookId)
                .IsRequired(true);
        }
    }
}
