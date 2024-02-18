using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;
using PokemonReviewAppp.Repository;

namespace PokemonReviewAppp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IOwnerRepository _owner;
        private readonly ICountryRespository _country;



        public OwnerController(IOwnerRepository repository,ICountryRespository CountryId, IMapper mapper)
        {
            _country = CountryId;
            _mapper = mapper;
            _owner = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owner = _mapper.Map<List<OwnerDto>>(_owner.GetOwners());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owner);
        }
        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwners(int ownerId)
        {
            if (!_owner.OwnerExists(ownerId))
                return NotFound();
            var owners = _mapper.Map<OwnerDto>(_owner.GetOwner(ownerId));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }

        [HttpGet("pokemon/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
         

            var pokemon = _mapper.Map<List<PokemonDto>>(
                _owner.GetPokemonByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int CountryId,[FromBody] OwnerDto ownerCreate)
        {
            if (CreateOwner == null)
                return BadRequest(ModelState);

            var owner = _owner.GetOwners().Where(o => o.LastName.Trim().ToUpper() == ownerCreate.LastName.TrimEnd()
            .ToUpper()).FirstOrDefault();


           

            if (owner != null)
            {
                ModelState.AddModelError("", "owner is already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var ownerMap = _mapper.Map<Owner>(ownerCreate);

            ownerMap.Country = _country.GetCountry(CountryId);
            if (!_owner.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "something happen while saving");
                return StatusCode(422, ModelState);
            }
            return Ok("Success");


        }
        [HttpPut("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]


        public IActionResult UpdateCountry(int ownerId, [FromBody] OwnerDto updateowner)
        {
            if (updateowner == null)
                return BadRequest(ModelState);

            if (ownerId != updateowner.id)
                return BadRequest(ModelState);

            if (!_owner.OwnerExists(ownerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownerMap = _mapper.Map<Owner>(updateowner);

            if (!_owner.Update(ownerMap))
            {
                ModelState.AddModelError("", "something went wrong updating");

                return StatusCode(500, ModelState);
            }
            return Ok("Update Success");
        }


        [HttpDelete("{ownerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult DeleteOwner(int ownerId)
        {
            if (!_owner.OwnerExists(ownerId))
            {
                return NotFound();

            }


            var ownerToDelete = _owner.GetOwner(ownerId);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_owner.Delete(ownerToDelete))
            {
                ModelState.AddModelError("", "Somethinng happen went  wrong deleting country");

            }
            return Ok("delete Success");







        }


    }
}
