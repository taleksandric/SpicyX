using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.DataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
