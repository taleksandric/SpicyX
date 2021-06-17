using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Type>
    {

        public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Meals).WithOne(x => x.Type).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
