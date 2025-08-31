using Auvo.GloboClima.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Infra.Data.Repositories
{
    public class FavoriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<bool> CreateAsync(Favorite movement, CancellationToken cancellationToken)
        //{
        //    await _context.MovimentosManuais.AddAsync(movement, cancellationToken);
        //    var success = await _context.SaveChangesAsync(cancellationToken);
        //    return success > 0;
        //}
    }
}
