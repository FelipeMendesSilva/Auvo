using Auvo.GloboClima.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Auvo.GloboClima.API.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(){}

        public IActionResult Index(CancellationToken cancellationToken)
        {            
            return Redirect("Country/CountryIndex");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
