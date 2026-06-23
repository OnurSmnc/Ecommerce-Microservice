using CatalogService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Entities
{
    public class Category : EntityBase
    {
        //private static int _idCounter = 1;
        public Category() { }
        public Category(string name, DateTime createdDate)
        {
            Name = name;
            CreatedDate = createdDate;
        }

        public Category(int id, string name, DateTime createdDate)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
        }

    }
}
