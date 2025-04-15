using Microsoft.AspNetCore.Mvc;

namespace IDSmarters.API.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
