namespace TechStore.Models
{
    public class Maker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Category>? Categories { get; set; }

        public ICollection<Product>? Products { get; set; }

        public int CountryId { get; set; }

        public string? Phone { get; set; }
    }
}
