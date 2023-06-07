using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;
namespace PokemonReviewAppp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _repository = pokemonRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]
        public IActionResult GetPokemons()
        {
            var Pokemons = _mapper.Map<List<PokemonDto>>(_repository.GetPokemons());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Pokemons);
        }
        [HttpGet("{PokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemons))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemons(int PokeId)
        {
            if (!_repository.PokemonExists(PokeId))
                return NotFound();
            var pokemon = _mapper.Map<PokemonDto>(_repository.GetPokemons(PokeId));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }
        [HttpGet("{PokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int PokeId)
        {
            if (!_repository.PokemonExists(PokeId))
                return NotFound();

            var rating = _repository.GetPokemonsRating(PokeId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }



    }
}
