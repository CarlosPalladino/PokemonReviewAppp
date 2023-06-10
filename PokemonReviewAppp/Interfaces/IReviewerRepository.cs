using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer>GetReviewers();

        Reviewer GetReviewers(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);

        bool ReviewerExits(int reviewerId);

        bool CreateReviewer(Reviewer reviewerId);

        bool UpdateReviewe(Reviewer reviewer);

        bool Save(Reviewer reviewer);


    }
}
