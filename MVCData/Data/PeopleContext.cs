using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    public class PeopleContext : IdentityDbContext<ApplicationUser>
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sverige" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Australien" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Stockholm", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Washington", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Sydney", CountryId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                Name = "TestPerson1",
                PhoneNumber = "001234567",
                CityId = 1
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                Name = "TestPerson2",
                PhoneNumber = "003554321",
                CityId = 2
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                Name = "TestPerson3",
                PhoneNumber = "004466732",
                CityId = 2,
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 4,
                Name = "TestPerson4",
                PhoneNumber = "0068995543",
                CityId = 3
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 5,
                Name = "TestPerson5",
                PhoneNumber = "00356446794",
                CityId = 3
            });

            modelBuilder.Entity<Language>().HasData(new Language { 
                LanguageId = 1,
                LanguageName = "Svenska"
            });
            modelBuilder.Entity<Language>().HasData(new Language
            {
                LanguageId = 2,
                LanguageName = "Amerikanska"
            });
            modelBuilder.Entity<Language>().HasData(new Language
            {
                LanguageId = 3,
                LanguageName = "Australienska"
            });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonLanguageId = 1, PersonRefId = 1, LanguageRefId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonLanguageId = 2, PersonRefId = 2, LanguageRefId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonLanguageId = 3, PersonRefId = 3, LanguageRefId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonLanguageId = 4, PersonRefId = 4, LanguageRefId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonLanguageId = 5, PersonRefId = 5, LanguageRefId = 3 });
        }
    }
}
