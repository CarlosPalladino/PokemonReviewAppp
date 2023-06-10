using Microsoft.EntityFrameworkCore;
using PokemonReviewAppp.Data;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemons> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemons GetPokemons(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemons GetPokemons(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();

        }

        public decimal GetPokemonsRating(int PokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == PokeId);

            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());

        }

        public bool PokemonExists(int PokeId)
        {

            return _context.Pokemon.Any(p => p.Id == PokeId);

        }


        public bool CreatePokemon(Pokemons Pokemon, int ownerId, int categoryId)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = Pokemon,
            };
            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = Pokemon,
            };
            _context.Add(Pokemon);
            _context.Add(pokemonCategory);
            return Save(Pokemon);
        }


        public bool Save(Pokemons Pokemon)
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(Pokemons Pokemon, int ownerId, int categoryId)
        {
            _context.Update(Pokemon);
            return Save(Pokemon);


        }

    }
}
