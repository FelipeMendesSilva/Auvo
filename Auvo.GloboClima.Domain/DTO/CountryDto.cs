using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace Auvo.GloboClima.Domain.DTO
{
    public class CountryDto
    {
        public CountryDto(
        string? name,
        string? currencies,
        string? capital,
        string? region,
        string? subregion,
        string? languages,
        string? latLng,
        bool landlocked,
        string? borders,
        double area,
        string? flag,
        long population,
        string? continents)
        {
            Name = name ?? "";
            Currencies = currencies ?? "";
            Capital = capital ?? "";
            Region = region ?? "";
            Subregion = subregion ?? "";
            Languages = languages ?? "";
            LatLng = latLng ?? "";
            Landlocked = landlocked;
            Borders = borders ?? "";
            Area = area;
            Flag = flag ?? "";
            Population = population;
            Continents = continents ?? "";
        }

        public string Name { get; set; }
        public string Currencies { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Languages { get; set; }
        public string LatLng { get; set; }
        public bool Landlocked { get; set; }
        public string Borders { get; set; }
        public double Area { get; set; }
        public string Flag { get; set; }
        public long Population { get; set; }
        public string Continents { get; set; }
    }
}
