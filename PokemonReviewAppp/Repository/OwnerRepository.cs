using Microsoft.EntityFrameworkCore;
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

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Owner> GetOwnersOFAPokemon(int PokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == PokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Pokemons> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p => ownerId == p.OwnerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }


        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save(owner);

        }

        public bool Save(Owner owner)
        {
            {
                var saved = _context.SaveChanges();

                return saved > 0 ? true : false;
            }
        }

        public bool Update(Owner owner)
        {
            _context.Update(owner);
            return Save(owner);
        }

        public bool Delete(Owner owner)
        {

            _context.Remove(owner);
            
            return Save(owner);
        }
    }
}
