using TechStore.Data;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            return Save();
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is not null)
            {
                _context.Categories.Remove(category);
                return Save();
            }
            return false;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
