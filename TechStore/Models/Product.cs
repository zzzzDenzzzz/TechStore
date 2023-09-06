﻿namespace TechStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MakerId { get; set; }

        public int? CategoryId { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public float Rating { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
