using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.OrderLines).WithOne(x => x.Meal).HasForeignKey(x => x.MealId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
