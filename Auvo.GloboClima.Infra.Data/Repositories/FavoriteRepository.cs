using Auvo.GloboClima.Domain.Entities;
using Auvo.GloboClima.Domain.Interfaces.Repositories;
using Auvo.GloboClima.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auvo.GloboClima.Infra.Data.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Favorite>> GetListByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            return await _context.Favorites                
                .Where(f => f.UserName == userName)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> AddAsync(Favorite favorite, CancellationToken cancellationToken)
        {
            await _context.Favorites.AddAsync(favorite, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteAsync(Favorite favorite, CancellationToken cancellationToken)
        {
            _context.Favorites.Remove(favorite);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
