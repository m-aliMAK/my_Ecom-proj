using Infra.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infra.Entities.Tables;
using System.Collections.Generic;

namespace Infra.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation Property to Stores (for store owners)
        public ICollection<Store> Stores { get; set; }
    }
}
