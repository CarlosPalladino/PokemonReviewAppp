using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsControllers : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviews;

        public ReviewsControllers(IReviewRepository repository, IMapper mapper)
        {

            _reviews = repository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviews.GetReviews());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);

        }
        [HttpGet("{ReviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int ReviewId)
        {
            if (!_reviews.ReviewExists(ReviewId))
                return NotFound();
            var reviews = _mapper.Map<ReviewDto>(_reviews.GetReview(ReviewId));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }

        [HttpGet("pokemon/{PokeId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsForAPokemon(int PokeId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(
                _reviews.GetReviewsOfAPokemon(PokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }


    }
}
