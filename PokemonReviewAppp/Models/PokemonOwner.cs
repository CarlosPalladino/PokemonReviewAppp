﻿
namespace PokemonReviewAppp.Models
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }

        public Pokemons Pokemon { get; set; }

        public Owner Owner { get; set; }

        public static explicit operator PokemonOwner(List<PokemonOwner> v)
        {
            throw new NotImplementedException();
        }
    }
}
