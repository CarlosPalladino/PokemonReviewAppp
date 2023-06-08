using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);

        ICollection<Owner> GetOwnersOFAPokemon(int PokeId);


        ICollection<Pokemons> GetPokemonsByOwner(int ownerId);

        bool OwnerExists(int ownerId);




    }
}
