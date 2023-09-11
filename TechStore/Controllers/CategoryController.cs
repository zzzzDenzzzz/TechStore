using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategoryById(int categoryId)
        {
            if (_categoryRepository.CategoryExists(categoryId)) return BadRequest();

            var category = _categoryRepository.GetCategory(categoryId);
            return Ok(category);
        }

        [HttpGet("test")]
        [HttpGet("word")]
        [HttpGet("potato/buy")]
        public IActionResult Test() => Ok("Test");

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (category == null) return BadRequest();

            if (!_categoryRepository.CreateCategory(category)) return StatusCode(500);

            return Ok("Category created succes");
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId)) return NotFound();

            if (!_categoryRepository.DeleteCategory(categoryId)) return StatusCode(500);

            return Ok("Deleted");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            if (category == null) return BadRequest();

            if (!_categoryRepository.UpdateCategory(category)) return StatusCode(500);

            return Ok("Updated");
        }
    }
}
