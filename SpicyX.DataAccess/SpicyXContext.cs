using Microsoft.EntityFrameworkCore;
using SpicyX.DataAccess.Configurations;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Type = SpicyX.Domain.Entities.Type;

namespace SpicyX.DataAccess
{
    public class SpicyXContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=STEVA-PC\SQLEXPRESS;Initial Catalog=AspSpicyX;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<User> Users { get; set; }
        


    }
}
