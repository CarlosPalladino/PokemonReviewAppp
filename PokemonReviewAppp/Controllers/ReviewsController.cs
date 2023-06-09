﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviews;
        private readonly IReviewerRepository _reviewers;
        private readonly IPokemonRepository _poke;



        public ReviewsController(IReviewRepository repository, IMapper mapper, IPokemonRepository pokemon, IReviewerRepository reviewer)
        {

            _reviews = repository;
            _mapper = mapper;
            _poke = pokemon;
            _reviewers = reviewer;
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
        public IActionResult GetReview(int ReviewId)
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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int PokeId, [FromBody] ReviewDto reviewCreate)
        {
            if (CreateReview == null)
                return BadRequest(ModelState);

            var review = _reviews.GetReviews()
                .Where(r => r.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd()
            .ToUpper()).FirstOrDefault();

            if (review != null)
            {
                ModelState.AddModelError("", "review is already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(reviewCreate);

            reviewMap.Pokemon = _poke.GetPokemons(PokeId);
            reviewMap.Reviewer = _reviewers.GetReviewers(reviewerId);

            if (!_reviews.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "something happen while saving");
                return StatusCode(422, ModelState);
            }
            return Ok("Success");


        }
        [HttpPut("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public IActionResult UpdateReview(int reviewId,
         [FromBody] ReviewDto updatereview)
        {
            if (updatereview == null)
                return BadRequest(ModelState);

            if (reviewId != updatereview.Id)
                return BadRequest(ModelState);

            if (!_reviews.ReviewExists(reviewId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(updatereview);

            if (!_reviews.UpdateReview(reviewMap))
            {
                ModelState.AddModelError("", "something went wrong updating");

                return StatusCode(500, ModelState);
            }
            return Ok("Update Success");

        }

        [HttpDelete("{reviewId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult DeleteReview(int reviewId)
        {
            if (!_reviews.ReviewExists(reviewId))
            {
                return NotFound();

            }
            var reviewToDelete = _reviews.GetReview(reviewId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_reviews.DeleteReview(reviewToDelete))
            {
                ModelState.AddModelError("", "Somethinng happen went  wrong deleting country");

            }
            return Ok("delete Success");
        }

    }
}