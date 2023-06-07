using AutoMapper;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Helper
{
    public class MappProfiles : Profile
    {
        public MappProfiles()
        {
            CreateMap<Pokemons, PokemonDto>();
            CreateMap<Category,CategoriesDto>();
            CreateMap<Country,CountryDto>();
        }
    }
}
