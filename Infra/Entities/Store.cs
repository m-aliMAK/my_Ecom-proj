using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }

        // Foreign key to ApplicationUser (Store Owner)
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        // Navigation property for related snaps
        public ICollection<StoreSnap> StoreSnaps { get; set; }
    }
}
