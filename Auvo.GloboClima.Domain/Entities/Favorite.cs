using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.GloboClima.Domain.Entities
{
    public class Favorite
    {
        public Favorite(string userId, List<string> favoritesCountries)
        {
            UserId = userId;
            FavoritesCountries = favoritesCountries;
        }
        public string UserId { get; private set; }
        public List<string> FavoritesCountries { get; private set; }
    }
}
