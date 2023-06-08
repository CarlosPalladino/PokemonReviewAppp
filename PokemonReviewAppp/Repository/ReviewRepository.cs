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

        public ReviewRepository(DataContext context,IMapper mapper )
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
     
            return  _context.Reviews.Any(r=> r.Id == ReviewId);

        }
    }
}
