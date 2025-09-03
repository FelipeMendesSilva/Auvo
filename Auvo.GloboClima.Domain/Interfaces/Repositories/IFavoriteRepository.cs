using Auvo.GloboClima.Domain.Entities;

namespace Auvo.GloboClima.Domain.Interfaces.Repositories
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetListByUserNameAsync(string userName, CancellationToken cancellationToken);
        Task<bool> AddAsync(Favorite favorite, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Favorite favorite, CancellationToken cancellationToken);
    }
}
