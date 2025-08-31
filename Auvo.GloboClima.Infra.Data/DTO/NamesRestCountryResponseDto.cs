using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Infra.Data.DTO
{
    public class NamesRestCountryResponseDto
    {
        public RestCountryName Name { get; set; }
    }

    public class RestCountryName
    {
        public string Common { get; set; }
    }
}
