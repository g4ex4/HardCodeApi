﻿namespace Domain
{
    public class CategoryField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
