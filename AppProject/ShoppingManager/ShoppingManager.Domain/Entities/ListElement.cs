using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManager.Domain.Entities
{
    public class ListElement
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsPurchased { get; set; }

        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }

        required public int ShoppingListId { get; set; }
        required public virtual ShoppingList ShoppingList { get; set; }


    }
}
