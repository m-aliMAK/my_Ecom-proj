using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dto
{
    public class StoreDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public OwnerDto? Owner { get; set; }
        public List<StoreSnapDto>? StoreSnaps { get; set; }
    }

    public class StoreSnapDto
    {
        public int StoreSnapId { get; set; }
        public string ImageUrl { get; set; }
        public int StoreId { get; set; }
        public StoreDto? Store { get; set; }
        public List<ProductDto>? Products { get; set; }
    }

    public class ProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        
    }
    public class ProductsDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<IFormFile> Image { get; set; }
    }

    public class OwnerDto
    {
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
    }


}
