using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAppp.dto;
using PokemonReviewAppp.Interfaces;
using PokemonReviewAppp.Models;

namespace PokemonReviewAppp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly IMapper _mapper;


        public CategoryController(ICategoryRepository category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoriesDto>>(_category.GetCategories());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }
        [HttpGet("{CategoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int CategoryId)
        {
            if (!_category.CategoriesExists(CategoryId))
                return NotFound();
            var categories = _mapper.Map<CategoriesDto>(_category.GetCategory(CategoryId));


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            var pokemon = _mapper.Map<List<PokemonDto>>(
                _category.GetPokemonsByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoriesDto categoryCreate)
        {
            if (CreateCategory == null)
                return BadRequest(ModelState);
            var category = _category.GetCategories().Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd()
            .ToUpper()).FirstOrDefault();
            if (category != null)
            {
                ModelState.AddModelError("", "category is already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoryMap = _mapper.Map<Category>(categoryCreate);
            if (!_category.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "something happen while saving");
                return StatusCode(422, ModelState);
            }
            return Ok("Success");

        }
        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]


        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoriesDto updatecategory)
        {
            if (updatecategory == null)
                return BadRequest(ModelState);

            if (categoryId != updatecategory.Id)
                return BadRequest(ModelState);

            if (!_category.CategoriesExists(categoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(updatecategory);

            if (!_category.UpdateCategory(categoryMap))
            {
                ModelState.AddModelError("", "something went wrong updating");

                return StatusCode(500, ModelState);
            }
            return Ok("Update Success");
        }


        [HttpDelete("{categoryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_category.CategoriesExists(categoryId))
            {
                return NotFound();

            }


            var categoryToDelete = _category.GetCategory(categoryId);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_category.Delete(categoryToDelete))
            {
                ModelState.AddModelError("", "Somethinng happen went  wrong deleting category");

            }
            return Ok("delete Success");







        }

    }


}

