using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            if (!_productRepository.ProductExists(productId)) return BadRequest();

            var product = _productRepository.GetProduct(productId);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product == null) return BadRequest();

            if (!_productRepository.CreateProduct(product)) return StatusCode(500);

            return Ok("Product created succes");
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            if (!_productRepository.ProductExists(productId)) return NotFound();

            if (!_productRepository.DeleteProduct(productId)) return StatusCode(500);

            return Ok("Deleted");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if (product == null) return BadRequest();

            if (!_productRepository.UpdateProduct(product)) return StatusCode(500);

            return Ok("Updated");
        }
    }
}
