using Infra.Data;
using Infra.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularEcommerceApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreSnapController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreSnapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/storesnap/{storeId}
        [HttpGet("{storeId}")]
        public async Task<ActionResult<IEnumerable<StoreSnap>>> GetStoreSnaps(int storeId)
        {
            return await _context.StoreSnaps
                .Where(s => s.StoreId == storeId)
                .Include(s => s.Products)  // Include products for each snap
                .ToListAsync();
        }

        // POST: api/storesnap
        [HttpPost]
        public async Task<ActionResult<StoreSnap>> PostStoreSnap(StoreSnap storeSnap)
        {
            _context.StoreSnaps.Add(storeSnap);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStoreSnaps), new { storeId = storeSnap.StoreId }, storeSnap);
        }
    }
}
