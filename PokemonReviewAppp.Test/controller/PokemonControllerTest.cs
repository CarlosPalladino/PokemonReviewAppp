using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.Controllers;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewAppp.Test.controller
{
    public class PokemonControllerTest
    {

        private readonly IPokemonRepository _repository;
        private readonly IReviewRepository _reviews;
        private readonly IMapper _mapper;

        public PokemonControllerTest()
        {
            _repository = A.Fake<IPokemonRepository>();
            _reviews = A.Fake<IReviewRepository>();
            _mapper = A.Fake<IMapper>();

        }

        [Fact]
        public void PokemonController_GetPokemons_ReturnOk()
        {
            //Arrange
            var pokemon = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _mapper.Map<List<PokemonDto>>(pokemon))
                .Returns(pokemonList);
            var controller = new PokemonController(_repository, _mapper, _reviews);

            //Actc
            var result = controller.GetPokemons();
            //assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void PokemonController_CreatePoke_ReturnOk()
        {
            int owner = 1;
            int catId = 2;
            var pokemonMap = A.Fake<Pokemons>();
            var pokemon = A.Fake<Pokemons>();
            var pokemonCreate = A.Fake<PokemonDto>();
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokeList = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _repository.GetPokemons().Where(p => p.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd()
             .ToUpper()).FirstOrDefault()).Returns(pokemon);
            A.CallTo(() => _mapper.Map<Pokemons>(pokemonCreate)).Returns(pokemon);
            A.CallTo(() => _repository.CreatePokemon(pokemonMap, owner, catId)).Returns(true);

            var controller = new PokemonController(_repository, _mapper, _reviews);

            var result = controller.CreatePokemon(owner, catId, pokemonCreate);

            result.Should().NotBeNull();
        }




    }













}
