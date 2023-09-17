using TechStore.Models;

namespace TechStore.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();

        Product GetProduct(int id);

        bool ProductExists(int id);

        bool CreateProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);

        bool Save();
    }
}
