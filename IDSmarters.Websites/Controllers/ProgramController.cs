using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDSmarters.Websites.Controllers
{
    public class ProgramController : Controller
    {
        // GET: ProgramController
        public ActionResult Index()
        {
            return View();
        }

    }
}
