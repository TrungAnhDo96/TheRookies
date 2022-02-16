using Microsoft.AspNetCore.Mvc;
using RK_A6.Facades;
using RK_A6.Interfaces;
using RK_A6.Models;
using RK_A6.Utilities;

namespace RK_A6.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;
        private IPeopleFacade _facade;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
            _facade = new PeopleFacade();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            var data = _facade.GetAllPeople();
            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel model)
        {
            _facade.AddPerson(model);

            return RedirectToAction("Members");
        }

        public IActionResult Edit(uint id)
        {
            PersonModel data = new PersonModel();
            if (id > 0)
            {
                data = _facade.GetPerson(id);
            }
            data.Id = id;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PersonModel model)
        {
            DateTime inputDate = DateAgeUtility.ParseDate(model.DateOfBirth);
            model.DateOfBirth = inputDate.ToString("dd/MM/yyyy");
            _facade.EditPerson(model);

            return RedirectToAction("Members");
        }

        public IActionResult Delete(PersonModel model)
        {
            _facade.DeletePerson(model);

            return RedirectToAction("Members");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}