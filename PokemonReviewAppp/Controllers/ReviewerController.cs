using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;
using PokemonReviewAppp.Repository;

namespace PokemonReviewAppp.Controllers
{
    public class ReviewerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviews;

        public ReviewerController(IReviewerRepository reviers, IMapper mapper)
        {
            _reviews = reviers;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewerDto>>(_reviews.GetReviewers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);

        }
        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int reviewerId)
        {
            if (!_reviews.ReviewerExits(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviews.GetReviewers(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }
        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewersByAReviewer(int reviewerId)
        {
            if (!_reviews.ReviewerExits(reviewerId))
                return NotFound();

            var reviewer = _reviews.GetReviewsByReviewer(reviewerId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }
    }
}
