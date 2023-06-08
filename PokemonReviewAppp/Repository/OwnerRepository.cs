using PokemonReviewAppp.Data;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public DataContext Context { get; }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.id == ownerId).FirstOrDefault();
        }


        public ICollection<Owner> GetOwnersOFAPokemon(int PokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == PokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();

        }



        public ICollection<Pokemons> GetPokemonsByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.id == ownerId).Select(p => p.Pokemon).ToList();

        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.id == ownerId);
        }
    }
}
