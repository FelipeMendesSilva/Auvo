namespace Auvo.GloboClima.Infra.Data.DTO
{
    public class CountryRestCountryResponseDto
    {
        public Name? name { get; set; }
        public List<string> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cioc { get; set; }
        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }
        public Dictionary<string, Currency> currencies { get; set; }
        public Idd idd { get; set; }
        public List<string> capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Dictionary<string, string> languages { get; set; }
        public List<double> latlng { get; set; }
        public bool landlocked { get; set; }
        public List<string> borders { get; set; }
        public double area { get; set; }
        public Dictionary<string, Demonym> demonyms { get; set; }
        public string cca3 { get; set; }
        public Dictionary<string, Translation> translations { get; set; }
        public string flag { get; set; }
        public Maps maps { get; set; }
        public long population { get; set; }
        public Dictionary<string, double> gini { get; set; }
        public string fifa { get; set; }
        public Car car { get; set; }
        public List<string> timezones { get; set; }
        public List<string> continents { get; set; }
        public FlagInfo flags { get; set; }
        public CoatOfArms coatOfArms { get; set; }
        public string startOfWeek { get; set; }
        public CapitalInfo capitalInfo { get; set; }
        public PostalCode postalCode { get; set; }
    }
    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public Dictionary<string, NativeName> nativeName { get; set; }
    }

    public class NativeName
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Currency
    {
        public string symbol { get; set; }
        public string name { get; set; }
    }

    public class Idd
    {
        public string root { get; set; }
        public List<string> suffixes { get; set; }
    }

    public class Demonym
    {
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Translation
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Maps
    {
        public string googleMaps { get; set; }
        public string openStreetMaps { get; set; }
    }

    public class Car
    {
        public List<string> signs { get; set; }
        public string side { get; set; }
    }

    public class FlagInfo
    {
        public string png { get; set; }
        public string svg { get; set; }
        public string alt { get; set; }
    }

    public class CoatOfArms
    {
        public string png { get; set; }
        public string svg { get; set; }
    }

    public class CapitalInfo
    {
        public List<double> latlng { get; set; }
    }

    public class PostalCode
    {
        public string format { get; set; }
        public string regex { get; set; }
    }
}
