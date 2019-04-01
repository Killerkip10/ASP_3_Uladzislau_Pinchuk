using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp2.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<ZodiacSign> ZodiacSigns { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<AdditionalService> AdditionalServices { get; set; }

        public DbSet<Customer> Customers { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=root;database=asplabs;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ZodiacSign>().HasData(
                new ZodiacSign[]
                {
                    new ZodiacSign { Id = 1, Name = "Ram", Description = "very stubborn" },
                    new ZodiacSign { Id = 2, Name = "Aquarius", Description = "wet" },
                    new ZodiacSign { Id = 3, Name = "Scorpio", Description = "dangerous" },
                }
                );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nationality>().HasData(
                new Nationality[]
                {
                    new Nationality { Id = 1, Name = "Belarus", Remarks = "cool people" },
                    new Nationality { Id = 2, Name = "Russian", Remarks = "countrymate" },
                    new Nationality { Id = 3, Name = "Pole", Remarks = "also countrymate" }
                }
               );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdditionalService>().HasData(
                new AdditionalService[]
                {
                    new AdditionalService { Id = 1, Name = "Ring", Description = "Gold", Price = 120 },
                    new AdditionalService { Id = 2, Name = "Angels", Description = "Milota", Price = 9999 },
                }
                );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerAdditional>().HasData(
                new CustomerAdditional[]
                {
                    new CustomerAdditional { Id = 1, AdditionalServiceId = 1, CustomerId = 1 },
                    new CustomerAdditional { Id = 2, AdditionalServiceId = 1, CustomerId = 2 },
                    new CustomerAdditional { Id = 3, AdditionalServiceId = 2, CustomerId = 3 },
                }
                );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer[]
                {
                    new Customer {
                        Id = 1, FullName = "Tom Anderson", Gender = "man",
                        Job = "Cleaner", Birthday = DateTime.Now.Date, Width = 100,
                        Weight = 100, CountChildren = 2, Adress = "gomel",
                        Phone = "+375298645383", Passport = "HB2721659", NationalityId = 1,
                        ZodiacSignId = 1,
                    },
                    new Customer {
                        Id = 2, FullName = "Vlad Pinchuk", Gender = "man",
                        Job = "Programmer", Birthday = DateTime.Now.Date, Width = 190,
                        Weight = 90, CountChildren = 0, Adress = "gomel",
                        Phone = "+37526702656", Passport = "HB27324329", NationalityId = 1,
                        ZodiacSignId = 2,
                    },
                    new Customer {
                        Id = 3, FullName = "Pavel Stelmah", Gender = "man",
                        Job = "Front end developer", Birthday = DateTime.Now.Date, Width = 100,
                        Weight = 80, CountChildren = 20, Adress = "gomel",
                        Phone = "+375292343483", Passport = "HB2722349", NationalityId = 3,
                        ZodiacSignId = 3,
                    },
                    //new Customer { Id=2, Name="Alice", Age=26},
                    //new Customer { Id=3, Name="Sam", Age=28}
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
