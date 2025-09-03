using Auvo.GloboClima.Domain.DTO;

namespace Auvo.GloboClima.Application.Interfaces
{
    public interface ICountryService
    {
        Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken);
        Task<CountryDto> GetCountryByNameAsync(string name, CancellationToken cancellationToken);
    }
}
