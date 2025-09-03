using Auvo.GloboClima.Domain.DTO;

namespace Auvo.GloboClima.Domain.Interfaces.Adapter
{
    public interface ICountryInfoAdapter
    {
        Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken);
        Task<CountryDto> GetCountryByNamesAsync(string name, CancellationToken cancellationToken);
    }
}
