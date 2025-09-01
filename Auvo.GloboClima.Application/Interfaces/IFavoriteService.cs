using Auvo.GloboClima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task<List<string>> GetFavoriteByUserNameAsync(string userName, CancellationToken cancellationToken);
        Task<bool> AddAsync(string userName, string countryName, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(string userName, string countryName, CancellationToken cancellationToken);
    }
}
