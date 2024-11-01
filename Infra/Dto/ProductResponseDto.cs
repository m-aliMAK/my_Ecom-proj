using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dto
{
    public class ProductResponseDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> ImageUrl { get; set; } // URLs as strings for display
    }
}
