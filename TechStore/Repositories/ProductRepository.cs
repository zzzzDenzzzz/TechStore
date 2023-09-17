using TechStore.Data;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            _context.Products.Add(product);
            return Save();
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == id);
            if (product is not null)
            {
                _context.Products.Remove(product);
                return Save();
            }
            return false;
        }

        public Product GetProduct(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

        public ICollection<Product> GetProducts() => _context.Products.ToList();

        public bool ProductExists(int id) => _context.Products.Any(p => p.Id == id);

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
