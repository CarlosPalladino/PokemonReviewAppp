using AutoMapper;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Helper
{
    public class MappProfiles : Profile
    {
        public MappProfiles()
        {
            CreateMap<Category, CategoriesDto>();
            CreateMap<CategoriesDto, Category>();

            CreateMap<Pokemons, PokemonDto>();
            CreateMap<PokemonDto, Pokemons>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();


            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();

            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();

            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();



        }
    }
}
