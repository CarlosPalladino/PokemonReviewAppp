using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemons> GetPokemonsByCategory(int categoryId);
        bool CategoriesExists(int id);
    }
}
