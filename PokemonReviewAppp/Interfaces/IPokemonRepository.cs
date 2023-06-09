using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface IPokemonRepository
    {

        ICollection<Pokemons> GetPokemons();

        Pokemons GetPokemons(int id);
        Pokemons GetPokemons(string name);
        decimal GetPokemonsRating(int PokeId);

        bool PokemonExists(int PokeId);


        bool CreatePokemon(Pokemons Pokemon, int ownerId, int categoryId);

        bool Save(Pokemons Pokemon);

    }
}
