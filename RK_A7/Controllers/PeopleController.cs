using Microsoft.AspNetCore.Mvc;
using RK_A7.Facades;
using RK_A7.Interfaces;
using RK_A7.Models;

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
            ViewBag.Members = data;
            return View();
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
            ViewBag.MemberToEdit = data;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(PersonModel model)
        {
            _facade.AddPerson(model);

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}