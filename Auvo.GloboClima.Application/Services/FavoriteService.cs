using Auvo.GloboClima.Application.Interfaces;
using Auvo.GloboClima.Domain.Entities;
using Auvo.GloboClima.Domain.Interfaces.Repositories;

namespace Auvo.GloboClima.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
                _favoriteRepository = favoriteRepository;
        }

        public async Task<List<string>> GetFavoriteByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            var favoriteList = await _favoriteRepository.GetListByUserNameAsync(userName, cancellationToken);
            return favoriteList.Select(x => x.FavoriteCountry).ToList();
        }

        public async Task<bool> AddAsync(string userName, string countryName, CancellationToken cancellationToken)
        {
            var fav = new Favorite(userName, countryName);
            return await _favoriteRepository.AddAsync(fav, cancellationToken);
        }

        public async Task<bool> DeleteAsync(string userName, string countryName, CancellationToken cancellationToken)
        {
            var fav = new Favorite(userName, countryName);
            return await _favoriteRepository.DeleteAsync(fav, cancellationToken);
        }
    }
}
