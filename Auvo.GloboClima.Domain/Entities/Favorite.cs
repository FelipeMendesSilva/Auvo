namespace Auvo.GloboClima.Domain.Entities
{
    public class Favorite
    {
        public Favorite(string userName, string favoriteCountry)
        {
            UserName = userName;
            FavoriteCountry = favoriteCountry;
        }
        public string UserName { get; private set; }
        public string FavoriteCountry { get; private set; }
    }
}
