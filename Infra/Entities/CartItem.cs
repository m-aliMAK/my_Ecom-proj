using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        // Foreign key to Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Quantity of the product in the cart
        public int Quantity { get; set; }

        // Foreign key to Cart
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
