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
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper, IOwnerRepository owner, ICategoryRepository category)
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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] PokemonDto pokemonCreate)
        {
            if (CreatePokemon == null)
                return BadRequest(ModelState);

            var owner = _repository.GetPokemons().Where(p => p.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd()
            .ToUpper()).FirstOrDefault();




            if (owner != null)
            {
                ModelState.AddModelError("", "pokemon is already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemons>(pokemonCreate);

            if (!_repository.CreatePokemon(pokemonMap, ownerId, categoryId))
            {
                ModelState.AddModelError("", "something happen while saving");
                return StatusCode(422, ModelState);
            }
            return Ok("Success");


        }
        [HttpPut("{pokemonId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]


        public IActionResult UpdatePokemopn(int pokemonId, [FromQuery] int ownerId,
            [FromQuery] int categoryId, [FromBody] PokemonDto updatepokemon)
        {
            if (updatepokemon == null)
                return BadRequest(ModelState);

            if (pokemonId != updatepokemon.Id)
                return BadRequest(ModelState);

            if (!_repository.PokemonExists(pokemonId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemons>(updatepokemon);

            if (!_repository.UpdatePokemon(pokemonMap, ownerId, categoryId))
            {
                ModelState.AddModelError("", "something went wrong updating");

                return StatusCode(500, ModelState);
            }
            return Ok("Update Success");





        }

    }
}
