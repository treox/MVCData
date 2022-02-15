using Microsoft.EntityFrameworkCore;
using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                Name = "TestPerson1",
                PhoneNumber = "001234567",
                City = "TestCity1"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                Name = "TestPerson2",
                PhoneNumber = "003554321",
                City = "TestCity2"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                Name = "TestPerson3",
                PhoneNumber = "004466732",
                City = "TestCity3"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 4,
                Name = "TestPerson4",
                PhoneNumber = "0068995543",
                City = "TestCity4"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 5,
                Name = "TestPerson5",
                PhoneNumber = "00356446794",
                City = "TestCity5"
            });
        }
    }
}
