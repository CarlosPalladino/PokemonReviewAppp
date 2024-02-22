using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAppp.Data;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context, IMapper mappper)
        {
            _context = context;
            _mapper = mappper;
        }

        public Reviewer GetReviewers(int reviewerId)
        {

            return _context.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.reviews).FirstOrDefault();
        }
        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExits(int reviewerId)
        {
            return _context.Reviews.Any(r => r.Id == reviewerId);
        }

        public bool ReviewExists(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.Id == reviewerId);
        }

        public bool CreateReviewer(Reviewer reviewerId)
        {
            _context.Reviewers.Add(reviewerId);
            return Save(reviewerId);
        }

        public bool Save(Reviewer reviewer)
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool UpdateReviewe(Reviewer reviewer)
        {

            _context.Update(reviewer);
            return Save(reviewer);

        }

        public bool Delete(Reviewer reviewer)
        {
            _context.Remove(reviewer);
            return Save(reviewer);

        }
    }
}
