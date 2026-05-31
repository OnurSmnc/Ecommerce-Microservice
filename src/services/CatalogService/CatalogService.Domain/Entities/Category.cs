using CatalogService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Entities
{
    public class Category : EntityBase
    {
        private static int _idCounter = 1;
        public Category() { }
        public Category(string name, DateTime createdDate)
        {
            Id = _idCounter++;
            Name = name;
            CreatedDate = createdDate;
        }
    }
}
