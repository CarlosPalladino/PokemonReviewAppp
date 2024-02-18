using System.ComponentModel;
using System.Xml.Linq;

namespace PokemonReviewAppp.Models
{
    public class Pokemons
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Image { get; set; }

        public string Tipo {  get; set; }
        public string Debilidad { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public ICollection<PokemonOwner> PokemonOwners { get; set; }

        public ICollection<PokemonCategory> PokemonCategories { get; set; }



    }

}

