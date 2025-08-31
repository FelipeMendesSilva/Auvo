using Auvo.GloboClima.Domain.DTO;
using Auvo.GloboClima.Domain.Interfaces;
using Auvo.GloboClima.Infra.Data.DTO;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Infra.Data.Adapters
{
    public class CountryInfoAdapter : ICountryInfoAdapter
    {
        public CountryInfoAdapter() { }
        
        public async Task<List<string>> GetAllCountryNamesAsync(CancellationToken cancellationToken)
        {
            var countryNames = new List<string>();
            var urlBase = "https://restcountries.com/v3.1/all?fields=name"; // URL da sua API

            var names = await urlBase
                .GetJsonAsync<List<NamesRestCountryResponseDto>>(); // Faz a requisição GET e desserializa o JSON para SuaClasseRetorno
                   
            foreach(var name in names)
            {
                countryNames.Add(name?.Name?.Common ?? "");
            }
            countryNames.Sort();

            return countryNames; 

        }

        public async Task<CountryDto> GetCountryByNamesAsync(string name, CancellationToken cancellationToken)
        {
            
            var urlBase = $"https://restcountries.com/v3.1/name/{name}"; // URL da sua API

            var responseList = await urlBase
                .GetJsonAsync<List<CountryRestCountryResponseDto>>(); // Faz a requisição GET e desserializa o JSON para SuaClasseRetorno
            var response = responseList.FirstOrDefault();

            var country = new CountryDto(
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

            return country;
        }
    }
}
