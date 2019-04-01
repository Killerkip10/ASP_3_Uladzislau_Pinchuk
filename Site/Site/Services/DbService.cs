using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp2.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Site.Services
{
    public class DbService
    {
        private readonly ApplicationContext _db;
        private readonly IMemoryCache _memoryCache;

        public DbService(ApplicationContext context, IMemoryCache memoryCache)
        {
            _db = context;
            _memoryCache = memoryCache;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customersList;

            if (_memoryCache.TryGetValue("customers", out customersList))
            {
                return customersList;
            }

            return _db.Customers.ToList();
        }

        public List<AdditionalService> GetAdditionalServices()
        {
            List<AdditionalService> additionalServicesList;

            if (_memoryCache.TryGetValue("services", out additionalServicesList))
            {
                return additionalServicesList;
            }

            return _db.AdditionalServices.ToList();
        }

        public List<Nationality> GetNationalities()
        {
            List<Nationality> nationalitiesList;

            if (_memoryCache.TryGetValue("nationalities", out nationalitiesList))
            {
                return nationalitiesList;
            }

            return _db.Nationalities.ToList();
        }

        public List<ZodiacSign> GetZodiacSigns()
        {
            List<ZodiacSign> zodiacSignsList;

            if (_memoryCache.TryGetValue("zodiacs", out zodiacSignsList))
            {
                return zodiacSignsList;
            }

            return _db.ZodiacSigns.ToList();
        }

        public AdditionalService AddAdditioonalService(string name, string description, double price)
        {
            AdditionalService service = new AdditionalService
            {
                Name = name,
                Description = description,
                Price = price,
            };

            _db.AdditionalServices.Add(service);
            _db.SaveChanges();

            _memoryCache.Remove("services");

            return service;
        }

        public Customer AddCustomer(
            string fullname,
            string gender,
            string job,
            DateTime birthday,
            int width,
            int weight,
            int countChild,
            string adress,
            string passport,
            int nationalityId,
            int zodiacSignId
        )
        {
            Customer customer = new Customer
            {
                FullName = fullname,
                Gender = gender,
                Job = job,
                Birthday = birthday,
                Width = width,
                Weight = weight,
                CountChildren = countChild,
                Adress = adress,
                Passport = passport,
                NationalityId = nationalityId,
                ZodiacSignId = zodiacSignId,
            };

            _db.Customers.Add(customer);
            _db.SaveChanges();

            _memoryCache.Remove("customers");

            return customer;
        }
    }
}
