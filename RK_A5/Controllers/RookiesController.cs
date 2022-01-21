using System;
using System.IO;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RK_A5.Enums;
using RK_A5.Facades;
using RK_A5.Interfaces;

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

        public FileResult ExportExcel()
        {
            var table = _facade.GetDataTable();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "PeopleWorksheet");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "People.xlsx");
                }
            }
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