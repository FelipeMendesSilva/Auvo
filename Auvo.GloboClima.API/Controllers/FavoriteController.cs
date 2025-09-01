using Auvo.GloboClima.API.Models;
using Auvo.GloboClima.Application.Interfaces;
using Auvo.GloboClima.Domain.DTO;
using Auvo.GloboClima.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace Auvo.GloboClima.API.Controllers
{
    [Authorize]
    [Route("Favorite")]
    public class FavoriteController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IFavoriteService _favoriteService; 
        private readonly UserManager<IdentityUser> _userManager;

        public FavoriteController(ILogger<CountryController> logger, IFavoriteService favoriteService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _favoriteService = favoriteService;
            _userManager = userManager;
        }


        [HttpGet("GetFavorites")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            var userName = User.Claims.First(x=>x.Type == ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"Usu�rio autenticado: {userName}");
            var user = await _userManager.GetUserAsync(User);
            if (userName == null)
                return NotFound("Usu�rio n�o encontrado.");

            var favoritelist = await _favoriteService.GetFavoriteByUserNameAsync(userName, cancellationToken);

            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<ul>");
            foreach (var item in favoritelist)
            {
                htmlBuilder.Append($"<li>{item}</li>");
            }
            htmlBuilder.Append("</ul>");

            return Content(htmlBuilder.ToString(), "text/html");
        }

        [HttpGet("AddFavorite")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddFavoriteAsync(string countryName, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) 
                return NotFound("Usu�rio n�o encontrado.");
            
            var added = await _favoriteService.AddAsync(user.Id,countryName, cancellationToken);
            if (!added)
                return StatusCode(500, "Erro ao adicionar o pa�s aos favoritos.");

            return Ok();
        }

        [HttpGet("DeleteFavorite")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteFavoriteAsync(string countryName, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound("Usu�rio n�o encontrado.");

            var deleted = await _favoriteService.DeleteAsync(user.Id, countryName, cancellationToken);
            if (!deleted)
                return StatusCode(500, "Erro ao deletar o pa�s aos favoritos.");

            return Ok();
        }
    }
}
