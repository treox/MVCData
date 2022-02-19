﻿// <auto-generated />
using MVCData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCData.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20220218105628_SeedDataForPersonLanguagesAdded")]
    partial class SeedDataForPersonLanguagesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCData.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnName("Namn")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Stockholm",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Washington",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Sydney",
                            CountryId = 3
                        });
                });

            modelBuilder.Entity("MVCData.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnName("Namn")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Sverige"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "USA"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Australien"
                        });
                });

            modelBuilder.Entity("MVCData.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnName("Språk")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            LanguageName = "Svenska"
                        },
                        new
                        {
                            LanguageId = 2,
                            LanguageName = "Amerikanska"
                        },
                        new
                        {
                            LanguageId = 3,
                            LanguageName = "Australienska"
                        });
                });

            modelBuilder.Entity("MVCData.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Namn")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("Telefonnummer")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            Name = "TestPerson1",
                            PhoneNumber = "001234567"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 2,
                            Name = "TestPerson2",
                            PhoneNumber = "003554321"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 2,
                            Name = "TestPerson3",
                            PhoneNumber = "004466732"
                        },
                        new
                        {
                            PersonId = 4,
                            CityId = 3,
                            Name = "TestPerson4",
                            PhoneNumber = "0068995543"
                        },
                        new
                        {
                            PersonId = 5,
                            CityId = 3,
                            Name = "TestPerson5",
                            PhoneNumber = "00356446794"
                        });
                });

            modelBuilder.Entity("MVCData.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonLanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageRefId")
                        .HasColumnType("int");

                    b.Property<int>("PersonRefId")
                        .HasColumnType("int");

                    b.HasKey("PersonLanguageId");

                    b.HasIndex("LanguageRefId");

                    b.HasIndex("PersonRefId");

                    b.ToTable("LanguageOwner");

                    b.HasData(
                        new
                        {
                            PersonLanguageId = 1,
                            LanguageRefId = 1,
                            PersonRefId = 1
                        },
                        new
                        {
                            PersonLanguageId = 2,
                            LanguageRefId = 2,
                            PersonRefId = 2
                        },
                        new
                        {
                            PersonLanguageId = 3,
                            LanguageRefId = 2,
                            PersonRefId = 3
                        },
                        new
                        {
                            PersonLanguageId = 4,
                            LanguageRefId = 3,
                            PersonRefId = 4
                        },
                        new
                        {
                            PersonLanguageId = 5,
                            LanguageRefId = 3,
                            PersonRefId = 5
                        });
                });

            modelBuilder.Entity("MVCData.Models.City", b =>
                {
                    b.HasOne("MVCData.Models.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCData.Models.Person", b =>
                {
                    b.HasOne("MVCData.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCData.Models.PersonLanguage", b =>
                {
                    b.HasOne("MVCData.Models.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCData.Models.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
