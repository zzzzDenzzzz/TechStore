namespace TechStore.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Rate { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}
