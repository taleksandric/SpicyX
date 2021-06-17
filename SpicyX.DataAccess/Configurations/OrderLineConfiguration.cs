using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");
        }
    }
}
