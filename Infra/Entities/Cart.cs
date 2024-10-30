using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Cart
    {
        public int CartId { get; set; }

        // Foreign key to ApplicationUser (Customer)
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

        // Navigation property for cart items
        public ICollection<CartItem> CartItems { get; set; }
    }
}
