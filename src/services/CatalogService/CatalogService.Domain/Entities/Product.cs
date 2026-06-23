using CatalogService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Entities
{
    public class Product: EntityBase
    {

        public Product() { }
        public Product(string name, string description, decimal price, int stock, int categoryId, DateTime createdDate)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            CreatedDate = createdDate;
        }
        public Product(int id, string name, string description, decimal price, int stock, int categoryId, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            CreatedDate = createdDate;
        }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
