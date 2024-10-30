using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class StoreSnap
    {
        public int StoreSnapId { get; set; }
        public string ImageUrl { get; set; } // URL of the uploaded snap

        // Foreign key to Store
        public int StoreId { get; set; }
        public Store Store { get; set; }

        // Navigation property for related products within the snap
        public ICollection<Product> Products { get; set; }
    }
}
