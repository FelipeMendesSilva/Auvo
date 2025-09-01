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
    [Route("Country")]
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;

        public CountryController(ILogger<CountryController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [HttpGet("CountryIndex")]
        public async Task<IActionResult> CountryIndexAsync(CancellationToken cancellationToken)
        {
            var countries = await _countryService.GetAllCountryNamesAsync(cancellationToken);
            var model = new CountryModel();
            model.CountryNames.AddRange(countries);
            return View("CountryIndex",model);
        }

        [HttpPost("GetCountry")]
        public async Task<IActionResult> GetCountryAsync( string countryName, CancellationToken cancellationToken)
        {
            var country = await _countryService.GetCountryByNameAsync(countryName, cancellationToken);

            var properties = typeof(CountryDto).GetProperties();
            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append($"<img src={country.FlagImg} alt =\"flag\" class =\"flag\" >");
            htmlBuilder.Append($"<div>");
            htmlBuilder.Append($"<h2>{country.Name}</h2><ul>");

            foreach (var prop in properties)
            {
                var value = prop.GetValue(country);
                htmlBuilder.Append($"<li><strong>{prop.Name}:</strong> {value}</li>");
            }
            htmlBuilder.Append($"</div>");

            return Content(htmlBuilder.ToString(), "text/html");
        }

        //[HttpGet("Favorites")]
        //[Authorize]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<IActionResult> FavoritesAsync(string userId, CancellationToken cancellationToken)
        //{
        //    var favoritelist = await _favoriteService.GetFavoriteByUserIdAsync(userId, cancellationToken);

        //    var htmlBuilder = new StringBuilder();

        //    htmlBuilder.Append("<ul>");
        //    foreach (var item in favoritelist)
        //    {
        //        htmlBuilder.Append($"<li>{item}</li>");
        //    }
        //    htmlBuilder.Append("</ul>");

        //    return Content(htmlBuilder.ToString(), "text/html");
        //}
    }
}
