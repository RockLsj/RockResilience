using Business.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCWeb.Controllers
{
    public class RegisterController : Controller
    {
        private static string strCurName = "";

        public IActionResult Index()
        {
            return View(new People());
        }

        public IActionResult Success()
        {
            ViewData["OperationDialogMsg"] = strCurName + " Register successfully!";
            return View();
        }

        [HttpPost]
        public IActionResult Index(People people)
        {
            if (!ModelState.IsValid)
            {
                return View(people);
            }
            strCurName = people.Name;
            return RedirectToAction("Success");
        }
    }
}
