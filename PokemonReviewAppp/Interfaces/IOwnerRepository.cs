using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);

        ICollection<Owner> GetOwnersOFAPokemon(int PokeId);


        ICollection<Pokemons> GetPokemonByOwner(int ownerId);

        bool OwnerExists(int ownerId);


        bool CreateOwner(Owner owner);

        bool Save(Owner owner);

    }
}