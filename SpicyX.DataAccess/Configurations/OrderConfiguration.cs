using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.OrderLines).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
