using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface ICountryRespository 
    {
        ICollection<Country>GetCountries();

        Country GetCountry(int id);

        Country GetCountryByOwner(int ownerId);

        ICollection<Owner> GetOwnersFromCountry(int countryId);

        bool CountryExits(int id);

        bool CreateCountry(Country country);

        bool Save(Country country);

        bool UpdateCountry(Country country);    


    }
}
