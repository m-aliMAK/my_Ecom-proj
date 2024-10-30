using Infra.Data;
using Infra.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularEcommerceApp.Controller
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-store")]
        public async Task<IActionResult> CreateStore([FromBody] Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return Ok(store);
        }

        [HttpPost("upload-snap/{storeId}")]
        public async Task<IActionResult> UploadSnap(int storeId, [FromForm] StoreSnap snap)
        {
            // Upload logic
            _context.StoreSnaps.Add(snap);
            await _context.SaveChangesAsync();
            return Ok(snap);
        }

        [HttpPost("add-product/{snapId}")]
        public async Task<IActionResult> AddProduct(int snapId, [FromBody] Product product)
        {
            //product.StoreSnapId = snapId;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}
