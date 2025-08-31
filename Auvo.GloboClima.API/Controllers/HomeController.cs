using Auvo.GloboClima.API.Models;
using Auvo.GloboClima.Application.Interfaces;
using Auvo.GloboClima.Domain.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Auvo.GloboClima.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;

        public HomeController(ILogger<HomeController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            var countries = await _countryService.GetAllCountryNamesAsync(cancellationToken);
            var model = new IndexModel();
            model.CountryNames.AddRange(countries);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetCountryAsync(string countryName, CancellationToken cancellationToken)
        {
            var country = await _countryService.GetCountryByNameAsync(countryName,cancellationToken);

            var properties = typeof(CountryDto).GetProperties();
            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append($"<h2>{country.Name}</h2><ul>");

            foreach (var prop in properties)
            {
                var value = prop.GetValue(country);
                htmlBuilder.Append($"<li><strong>{prop.Name}:</strong> {value}</li>");
            }

            htmlBuilder.Append("</ul></body></html>");

            return Content(htmlBuilder.ToString(), "text/html");
        }

        [Authorize]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Favorites()
        {
            var itens = new List<string> { "Maçã", "Banana", "Laranja" };

            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<ul>");
            foreach (var item in itens)
            {
                htmlBuilder.Append($"<li>{item}</li>");
            }
            htmlBuilder.Append("</ul>");

            return Content(htmlBuilder.ToString(), "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
