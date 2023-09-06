using TechStore.Models;

namespace TechStore.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int id);

        bool CategoryExists(int id);

        ICollection<Product> GetProductsByCategoryId(int categoryId);

        bool CreateCategory(Category category);

        bool UpdateCategory(Category category);

        bool DeleteCategory(int id);

        bool Save();
    }
}
