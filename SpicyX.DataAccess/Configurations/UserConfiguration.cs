using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Reservations).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
