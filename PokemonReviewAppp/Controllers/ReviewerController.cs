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
    public class ReviewerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewers;

        public ReviewerController(IReviewerRepository reviers, IMapper mapper)
        {
            _reviewers = reviers;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewers.GetReviewers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int reviewerId)
        {
            if (!_reviewers.ReviewerExits(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviewers.GetReviewers(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAReviewer(int reviewerId)
        {
            if (!_reviewers.ReviewerExits(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(
                   _reviewers.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            if (CreateReviewer == null)
                return BadRequest(ModelState);

            var review = _reviewers.GetReviewers()
                .Where(r => r.FirstName.Trim().ToUpper() == reviewerCreate.LastName.TrimEnd()
            .ToUpper()).FirstOrDefault();

            if (review != null)
            {
                ModelState.AddModelError("", "reviewer is already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Reviewer>(reviewerCreate);


            if (!_reviewers.CreateReviewer(reviewMap))
            {
                ModelState.AddModelError("", "something happen while saving");
                return StatusCode(422, ModelState);
            }
            return Ok("Success");


        }
        [HttpPut("{reviewerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public IActionResult UpdateReview(int reviewerId,
      [FromBody] ReviewerDto updatereviewer)
        {
            if (updatereviewer == null)
                return BadRequest(ModelState);

            if (reviewerId != updatereviewer.Id)
                return BadRequest(ModelState);

            if (!_reviewers.ReviewerExits(reviewerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<Reviewer>(updatereviewer);

            if (!_reviewers.UpdateReviewe(reviewerMap))
            {
                ModelState.AddModelError("", "something went wrong updating");

                return StatusCode(500, ModelState);
            }
            return Ok("Update Success");

        }
    }
}