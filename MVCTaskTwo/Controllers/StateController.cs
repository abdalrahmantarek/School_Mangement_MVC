using Microsoft.AspNetCore.Mvc;

namespace MVCTaskTwo.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Set()
        {
            HttpContext.Session.SetString("Name", "Abdo");

            return Content("Save");
        }

        public IActionResult Get1()
        {
           string n=  HttpContext.Session.GetString("Name")??"null";

            return Content($"hello {n}");
        }
    }
}
