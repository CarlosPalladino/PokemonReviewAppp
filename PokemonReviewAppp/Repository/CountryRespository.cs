using AutoMapper;
using PokemonReviewAppp.Data;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Repository
{
    public class CountryRespository : ICountryRespository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRespository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public bool CountryExits(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }


        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
                }

        public Country GetCountry(int id)
        {
                return _context.Countries.Where(c  => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {

            return _context.Owners.Where(o => o.id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id ==countryId).ToList();

        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);

            return Save(country);
        }
        public bool Save(Country country)
        {
        var saved =  _context.SaveChanges();

            return saved >  0 ? true : false;

        }

    
    }
}
