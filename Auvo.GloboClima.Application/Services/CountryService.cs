using Auvo.GloboClima.Application.Interfaces;
using Auvo.GloboClima.Domain.DTO;
using Auvo.GloboClima.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;

namespace Auvo.GloboClima.Application.Services;
public class CountryService : ICountryService
{
    private readonly IMemoryCache _cache;
    private readonly ICountryInfoAdapter _countryInfoAdapter;
    private const string CountryNamesCacheKey = "CountryNames";

    public CountryService(IMemoryCache cache, ICountryInfoAdapter countryInfoAdapter)
    {
        _cache = cache;
        _countryInfoAdapter = countryInfoAdapter;
    }

    public async Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue(CountryNamesCacheKey, out List<string>? cachedCountryNames))
        {
            return cachedCountryNames ?? new();
        }

        var countryNames = await _countryInfoAdapter.GetAllCountryNamesAsync(cancellationToken);

        _cache.Set(CountryNamesCacheKey, countryNames, TimeSpan.FromHours(1));

        return countryNames;
    }

    public async Task<CountryDto> GetCountryByNameAsync(string name, CancellationToken cancellationToken)
    {       
        var country = await _countryInfoAdapter.GetCountryByNamesAsync(name, cancellationToken);        

        return country;
    }
}
