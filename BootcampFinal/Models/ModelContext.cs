using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingFlat> BuildingFlats { get; set; }
        public DbSet<FlatType> FlatTypes{ get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Ali",
                LastName = "Yavuz",
                Email = "admin@mail.com",
                Password = "123123",
                PhoneNumber = "05056424177",
                TCKN = "123456778901",
                UserRole = UserRole.Administrator
            });
        }
    }
}
