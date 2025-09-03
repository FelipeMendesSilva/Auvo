using Auvo.GloboClima.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace Auvo.GloboClima.API.Controllers
{
    [Authorize]
    [Route("Favorite")]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService; 

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("GetFavorites")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            var userName = GetUserName();
            if (userName == null)
                return NotFound("Usuário não encontrado.");

            var favoritelist = await _favoriteService.GetFavoriteByUserNameAsync(userName, cancellationToken);
            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<ul>");
            foreach (var item in favoritelist)
            {
                htmlBuilder.Append($"<li class=\"canClick\">{item}</li>");
            }
            htmlBuilder.Append("</ul>");

            return Content(htmlBuilder.ToString(), "text/html");
        }

        [HttpPost("AddFavorite")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddFavoriteAsync(string countryName, CancellationToken cancellationToken)
        {

            var userName = GetUserName();
            if (userName == null)
                return NotFound("Usuário não encontrado.");

            var added = await _favoriteService.AddAsync(userName, countryName, cancellationToken);
            if (!added)
                return StatusCode(500, "Erro ao adicionar o país aos favoritos.");

            return Ok();
        }

        [HttpDelete("DeleteFavorite")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteFavoriteAsync(string countryName, CancellationToken cancellationToken)
        {

            var userName = GetUserName();
            if (userName == null)
                return NotFound("Usuário não encontrado.");

            var deleted = await _favoriteService.DeleteAsync(userName, countryName, cancellationToken);
            if (!deleted)
                return StatusCode(500, "Erro ao deletar o país aos favoritos.");

            return Ok();
        }

        private string? GetUserName() => User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier && !Guid.TryParse(x.Value, out _))?.Value;
    }
}
