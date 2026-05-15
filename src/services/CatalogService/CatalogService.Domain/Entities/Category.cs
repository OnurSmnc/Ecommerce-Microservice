using CatalogService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category() { }
        public Category(string name, DateTime createdDate)
        {
            Name = name;
            CreatedDate = createdDate;
        }
    }
}
