using PokemonReviewAppp.Data;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }


        public bool CategoriesExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }


        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemons> GetPokemonsByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c => categoryId == c.CategoryId).Select(c => c.Pokemon).ToList();
        }


        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            //_context.SaveChanges();
         return    Save(category);
        }

        public bool Save(Category category)
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
