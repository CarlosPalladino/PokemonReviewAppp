using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.dto
{
    public class PokemonDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
