using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManager.Domain.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        required public string Name { get; set; }

        public virtual ICollection<ListElement>? ListElements { get; set; }

        public virtual ICollection<ListAccess>? ListAccesses { get; set; }

        public void AddElement(ListElement element)
        {
            // Implementation for adding an element to the shopping list
        }

        public void RemoveElement(int elementId)
        {
            // Implementation for removing an element from the shopping list
        }

        public void EditElement(int elementId)
        {
            // Implementation for editing an element from the shopping list
        }
    }
}
