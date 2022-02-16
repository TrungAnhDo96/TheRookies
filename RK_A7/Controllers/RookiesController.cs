using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using RK_A7.Enums;
using RK_A7.Facades;
using RK_A7.Interfaces;
using RK_A7.Models;

namespace RK_A7.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        private IPeopleFacade _facade;

        public RookiesController(ILogger<RookiesController> logger, IPeopleFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }

        public IActionResult GenderPage()
        {
            var data = _facade.GetPeopleByGender(Gender.Male);
            ViewBag.MalePeople = data;
            return View();
        }

        public IActionResult NamePage()
        {
            var data = _facade.GetFullName();
            ViewBag.PeopleName = data;
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