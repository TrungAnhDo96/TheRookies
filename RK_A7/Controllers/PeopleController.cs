using Microsoft.AspNetCore.Mvc;
using RK_A7.Interfaces;
using RK_A7.Models;
using RK_A7.Utilities;

namespace RK_A6.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;
        private IPeopleFacade _facade;

        public PeopleController(ILogger<PeopleController> logger, IPeopleFacade facade)
        {
            _logger = logger;
            _facade = facade;
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

        public IActionResult MemberDetails(uint id)
        {
            PersonModel data = new PersonModel();
            if (id > 0)
            {
                data = _facade.GetPerson(id);
            }
            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel model)
        {
            DateTime inputDate = DateAgeUtility.ParseDate(model.DateOfBirth);
            model.DateOfBirth = inputDate.ToString("dd/MM/yyyy");
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

        public IActionResult DeleteConfirmation()
        {
            var data = HttpContext.Session.GetString("DeletedName");
            ViewBag.DeletedName = data;
            return View();
        }

        public IActionResult Delete(uint id)
        {
            PersonModel model = _facade.GetPerson(id);
            HttpContext.Session.SetString("DeletedName", model.FirstName + ' ' + model.LastName);
            _facade.DeletePerson(model);

            return RedirectToAction("DeleteConfirmation");
        }

        [HttpPost]
        public IActionResult DeletePerson(PersonModel model)
        {
            PersonModel fullModel = _facade.GetPerson(model.Id);
            HttpContext.Session.SetString("DeletedName", fullModel.FirstName + ' ' + fullModel.LastName);
            _facade.DeletePerson(fullModel);

            return RedirectToAction("DeleteConfirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}