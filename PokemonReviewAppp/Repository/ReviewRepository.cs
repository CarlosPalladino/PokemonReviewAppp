using AutoMapper;
using PokemonReviewAppp.Data;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Review GetReview(int id)
        {

            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int PokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == PokeId).ToList();
        }



        public bool ReviewExists(int ReviewId)
        {

            return _context.Reviews.Any(r => r.Id == ReviewId);

        }

        public bool CreateReview(Review reviewId)
        {
            _context.Add(reviewId);
            return Save();

        }



        public bool UpdateReview(Review review)
        {

            _context.Update(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
