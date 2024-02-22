//using AutoMapper.Configuration.Annotations;
//using FluentAssertions;
//using Microsoft.EntityFrameworkCore;
//using PokemonReviewAppp.Data;
//using PokemonReviewAppp.Interfaces;
//using PokemonReviewAppp.Models;
//using PokemonReviewAppp.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization.Formatters;
//using System.Text;
//using System.Threading.Tasks;

//namespace PokemonReviewAppp.Test.Repository
//{
//    public class PokemonRepositoryTest
//    {
//        private async Task<DataContext> GetDataBaseContext()
//        {
//            var options = new DbContextOptionsBuilder<DataContext>()
//            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//            .Options;
//            var databaseContext = new DataContext(options);
//            databaseContext.Database.EnsureCreated();
//            if (await databaseContext.Pokemon.CountAsync() <= 0)
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    databaseContext.Pokemon.Add(

//                          new Pokemons()
//                          {
//                              Name = "Pikachu",
//                              BirthDate = new DateTime(1903, 1, 1),
//                              PokemonCategories = new List<PokemonCategory>()
//                            {
//                                new PokemonCategory { Category = new Category() { Name = "Electric"}}
//                            },
//                              Reviews = new List<Review>()
//                            {
//                                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
//                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
//                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
//                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
//                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
//                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
//                            }

//                          });
//                    await databaseContext.SaveChangesAsync();

//                }
//            }
//            return databaseContext;
//        }

//        [Fact(Skip = "No implementado aún")]
//        public async void Pokemon_GetRating_returnRating()
//        {
//            var PokeId = 1;
//            var dbContext = await GetDataBaseContext();
//            var pokemonRepository = new PokemonRepository(dbContext);

//            var Rs = pokemonRepository.GetPokemonsRating(PokeId);

//            Rs.Should().NotBe(0);

//        }
       












//    }
//}

