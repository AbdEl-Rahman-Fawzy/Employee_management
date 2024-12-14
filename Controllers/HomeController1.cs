using Microsoft.AspNetCore.Mvc;

namespace edu.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
