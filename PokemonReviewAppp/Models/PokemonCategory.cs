namespace PokemonReviewAppp.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemons Pokemon { get; set; }

        public Category Category { get; set; }

    }
}
