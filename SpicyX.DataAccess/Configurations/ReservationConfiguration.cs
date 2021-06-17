using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.HowManyPeople).IsRequired();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");


        }
    }
}
