using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRespository _respository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRespository repository, IMapper mapper)

        {
            _mapper = mapper;
            _respository = repository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var country = _mapper.Map<List<CountryDto>>(_respository.GetCountries());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Pokemons))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_respository.CountryExits(countryId))
                return NotFound();
            var country = _mapper.Map<CountryDto>(_respository.GetCountry(countryId));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);



        }
        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetContryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(
                _respository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);

        }




    }
}
