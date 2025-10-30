using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManager.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        required public string Name { get; set; }
        public string? Unit { get; set; }
        public string? Company { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public virtual ProductCategory? Category { get; set; }
    }
}
