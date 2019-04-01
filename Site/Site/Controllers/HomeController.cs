using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using ConsoleApp2.Models;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly DbService _dbService;

        public HomeController(ApplicationContext db, DbService dbService)
        {
            _db = db;
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View("Home");
        }

        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Customers()
        {
            ViewBag.Nationalities = _dbService.GetNationalities();
            ViewBag.ZodiacSigns = _dbService.GetZodiacSigns();

            if (HttpContext.Session.Keys.Contains("Customer"))
            {
                ViewBag.Customer = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Customer"));
            }
            else
            {
                ViewBag.Customer = new Customer()
                {
                    FullName = "",
                    Gender = "",
                    Job = "",
                    Birthday = new DateTime(),
                    Width = 0,
                    Weight = 0,
                    CountChildren = 0,
                    Adress = "",
                    Phone = "",
                    Passport = "",
                    ZodiacSignId = 1,
                    NationalityId = 1
                };
            }

            return View(_dbService.GetCustomers());
        }

        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Services()
        {
            if (Request.Cookies.ContainsKey("Service"))
            {
                ViewBag.ServiceInCookie = JsonConvert.DeserializeObject<AdditionalService>(Request.Cookies["Service"]);
            }
            else
            {
                ViewBag.ServiceInCookie = new AdditionalService()
                {
                    Name = "",
                    Description = "",
                    Price = 0,
                };
            }

            return View(_dbService.GetAdditionalServices());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CreateService(string name, string description, double price)
        {
            AdditionalService createdService = _dbService.AddAdditioonalService(name, description, price);

            Response.Cookies.Append("Service", JsonConvert.SerializeObject(createdService));

            return RedirectToAction("Services");
        }

        [HttpPost]
        public IActionResult CreateCustomer(
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
            Customer createdCustomer = _dbService.AddCustomer(
                fullname,
                gender,
                job,
                birthday,
                width,
                weight,
                countChild,
                adress,
                passport,
                nationalityId,
                zodiacSignId
            );

            HttpContext.Session.SetString("Customer", JsonConvert.SerializeObject(createdCustomer));
            //Response.Cookies.Append("Service", JsonConvert.SerializeObject(createdService));

            return RedirectToAction("Customers");
        }

       
    }
}
