using Auvo.GloboClima.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Application.Interfaces
{
    public interface ICountryService
    {
        Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken);
        Task<CountryDto> GetCountryByNameAsync(string name, CancellationToken cancellationToken);
    }
}
