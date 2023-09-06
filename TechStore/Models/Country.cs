﻿namespace TechStore.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Maker>? Makers { get; set; }
    }
}
