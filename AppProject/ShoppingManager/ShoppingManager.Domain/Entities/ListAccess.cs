using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManager.Domain.Entities
{
    public class ListAccess
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public int UserId { get; set; }
    }
}
