using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReview(int id);

        ICollection<Review> GetReviewsOfAPokemon(int PokeId);

        bool ReviewExists(int ReviewId);


        bool CreateReview(Review reviewId);

        bool Save(Review review);

    }
}
