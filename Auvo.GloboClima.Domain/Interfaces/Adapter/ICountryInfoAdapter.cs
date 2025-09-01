using Auvo.GloboClima.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Domain.Interfaces.Adapter
{
    public interface ICountryInfoAdapter
    {
        Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken);
        Task<CountryDto> GetCountryByNamesAsync(string name, CancellationToken cancellationToken);
    }
}
