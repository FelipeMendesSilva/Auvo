using Microsoft.AspNetCore.Mvc;

namespace Auvo.GloboClima.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
