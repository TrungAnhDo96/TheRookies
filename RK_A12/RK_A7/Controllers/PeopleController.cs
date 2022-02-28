using Microsoft.AspNetCore.Mvc;
using RK_A7.Interfaces;
using RK_A7.Models;
using RK_A7.Utilities;

namespace RK_A7.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;
        private IPeopleService _service;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            var data = _service.GetAllPeople();
            return View(data);
        }

        public IActionResult MemberDetails(int id)
        {
            PersonModel data = new PersonModel();
            if (id > 0)
            {
                data = _service.GetPerson(id);
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
            _service.AddPerson(model);

            return RedirectToAction("Members");
        }

        public IActionResult Edit(int id)
        {
            PersonModel data = new PersonModel();
            if (id > 0)
            {
                data = _service.GetPerson(id);
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int id, PersonModel model)
        {
            DateTime inputDate = DateAgeUtility.ParseDate(model.DateOfBirth);
            model.DateOfBirth = inputDate.ToString("dd/MM/yyyy");
            _service.EditPerson(id, model);

            return RedirectToAction("Members");
        }

        public IActionResult DeleteConfirmation()
        {
            //var data = HttpContext.Session.GetString("DeletedName");
            //ViewBag.DeletedName = data;
            return View();
        }

        public IActionResult Delete(int id)
        {
            //var model = _service.GetPerson(id);
            //HttpContext.Session.SetString("DeletedName", model.FirstName + ' ' + model.LastName);
            _service.DeletePerson(id);

            return RedirectToAction("DeleteConfirmation");
        }

        [HttpPost]
        public IActionResult DeletePerson(PersonModel model)
        {
            //HttpContext.Session.SetString("DeletedName", model.FirstName + ' ' + model.LastName);
            _service.DeletePerson(model.Id);

            return RedirectToAction("DeleteConfirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}