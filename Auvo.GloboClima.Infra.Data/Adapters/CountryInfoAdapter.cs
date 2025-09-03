using Auvo.GloboClima.Domain.DTO;
using Auvo.GloboClima.Domain.Interfaces.Adapter;
using Auvo.GloboClima.Infra.Data.DTO;
using Auvo.GloboClima.Infra.Data.IoC;
using Flurl.Http;
using Microsoft.Extensions.Options;

namespace Auvo.GloboClima.Infra.Data.Adapters
{
    public class CountryInfoAdapter : ICountryInfoAdapter
    {
        private readonly IOptions<CountryOptions> _countryOptions;
        public CountryInfoAdapter(IOptions<CountryOptions> countryOptions) 
        {
            _countryOptions = countryOptions;
        }
        
        public async Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken)
        {
            var countryNames = new List<string>();
            var urlBase = _countryOptions.Value.GetAllCountries; 

            var names = await urlBase
                .GetJsonAsync<List<NamesRestCountryResponseDto>>(); 
                   
            foreach(var name in names)
            {
                countryNames.Add(name?.Name?.Common ?? "");
            }
            countryNames.Sort();

            return countryNames; 
        }

        public async Task<CountryDto> GetCountryByNamesAsync(string name, CancellationToken cancellationToken)
        {            
            var urlBase = $"{_countryOptions.Value.GetCountryByName}{name}"; 

            var responseList = await urlBase
                .GetJsonAsync<List<CountryRestCountryResponseDto>>(); 
            var response = responseList.FirstOrDefault();

            return new CountryDto(
                response?.name?.common,
                string.Join(",", response.currencies.Select(kvp => $"{kvp.Key}:{kvp.Value.symbol}-{kvp.Value.name}")),
                string.Join(",", response.capital),
                response.region,
                response.subregion,
                string.Join(",", response.languages.Select(kvp => $"{kvp.Key}:{kvp.Value}")),
                string.Join(",", response.latlng),
                response.landlocked,
                string.Join(",", response.borders),
                response.area,
                response.flag,
                response.flags.svg,
                response.population,
                string.Join(",", response.continents));             
        }
    }
}
