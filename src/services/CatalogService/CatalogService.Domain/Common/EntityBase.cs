using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
