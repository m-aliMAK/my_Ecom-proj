using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infra.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //public ICollection<Images> ImageUrl { get; set; } //= new List<Images>();
        public string ImageUrl { get; set; }
        //public int Quantity { get; set; }

        //// Foreign key to StoreSnap
        //public int StoreSnapId { get; set; }
        //public StoreSnap StoreSnap { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
