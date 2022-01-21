using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RK_A5.Enums;
using RK_A5.Facades;
using RK_A5.Interfaces;
using RK_A5.Models;

namespace RK_A5.Controllers
{
    //[Route("[controller]")]
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        private IPeopleFacade _facade;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
            _facade = new PeopleFacade();
        }

        public IActionResult GenderPage()
        {
            var data = _facade.GetPeopleByGender(Gender.Male);
            ViewBag.MalePeople = data;
            return View();
        }

        public IActionResult Oldest()
        {
            var data = _facade.GetOldestPerson();
            ViewBag.OldestPerson = data;
            return View();
        }

        public IActionResult BirthYearPage(int year)
        {
            var peopleYearEqualData = _facade.GetPeopleByBirthYear(year);
            var peopleYearGreaterData = _facade.GetPeopleByBirthYearGreater(year);
            var peopleYearLessData = _facade.GetPeopleByBirthYearLess(year);
            ViewBag.PeopleWithBirthYearEqual = peopleYearEqualData;
            ViewBag.PeopleWithBirthYearGreater = peopleYearGreaterData;
            ViewBag.PeopleWithBirthYearLess = peopleYearLessData;
            ViewBag.InputYear = Convert.ToInt32(HttpContext.Request.Query["year"]);
            return View();
        }

        public IActionResult Export()
        {
            var builder = new StringBuilder();
            builder.AppendLine("FirstName,LastName,Gender,DOB,Phone,BirthPlace,Graduated");
            foreach (var person in _facade.GetAllPeople())
            {
                builder.AppendLine($"{person.FirstName},{person.LastName},{person.Gender},{person.DateOfBirth},{person.PhoneNumber},{person.BirthPlace},{person.IsGraduated}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "people.csv");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}