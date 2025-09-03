using Auvo.GloboClima.API.Models;
using Auvo.GloboClima.Application.Interfaces;
using Auvo.GloboClima.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace Auvo.GloboClima.API.Controllers
{
    [Route("Country")]
    public class CountryController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        private readonly ICountryService _countryService;

        public CountryController(IFavoriteService favoriteService, ICountryService countryService)
        {
            _countryService = countryService;
            _favoriteService = favoriteService;
        }

        [HttpGet("CountryIndex")]
        public async Task<IActionResult> CountryIndexAsync(CancellationToken cancellationToken)
        {
            var countries = await _countryService.GetAllCountryNamesAsync(cancellationToken);
            var model = new CountryModel();
            model.CountryNames.AddRange(countries);
            return View("CountryIndex", model);
        }

        [HttpPost("GetCountry")]
        public async Task<IActionResult> GetCountryAsync(string countryName, CancellationToken cancellationToken)
        {
            var country = await _countryService.GetCountryByNameAsync(countryName, cancellationToken);
            var htmlCountry = GenerateCountryHtml(country);
            bool isFavorite = false;

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Claims.First(x => x.Type == ClaimTypes.Name)?.Value;
                var favorites = await _favoriteService.GetFavoriteByUserNameAsync(userName ?? "", cancellationToken);

                isFavorite = favorites.Contains(country.Name);
            }

            return Json(new { html = htmlCountry, isFavorite });
        }

        private static string GenerateCountryHtml(CountryDto? country)
        {
            if (country == null)
                return "<div/>";

            var properties = typeof(CountryDto).GetProperties();
            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append($"<img src={country.FlagImg} alt =\"flag\" class =\"flag\" >");
            htmlBuilder.Append($"<div class=\"countryInfo\">");
            htmlBuilder.Append($"<h2>{country.Name}</h2><ul>");

            foreach (var prop in properties)
            {
                var value = prop.GetValue(country);
                if (prop.Name == "FlagImg")
                    htmlBuilder.Append($"<li><strong>{prop.Name}:</strong><a href=\" {value}\">link</a></li>");
                else
                    htmlBuilder.Append($"<li><strong>{prop.Name}:</strong> {value}</li>");
            }
            htmlBuilder.Append($"</ul></div>");

            return htmlBuilder.ToString();
        }
    }
}
