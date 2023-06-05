namespace PokemonReviewAppp.Models
{
    public class Owner
    {

        public int id { get; set; }
        public string? Name  { get; set; }
        public string? Gym { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country?Country { get; set; }
        //public ICollection<Pokemon> Pokemon { get; set; }   

        public ICollection<PokemonOwner> PokemonOwner { get; set; } 

    }
}
