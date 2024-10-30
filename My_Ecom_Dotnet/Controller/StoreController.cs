using Infra.Data;
using Infra.Dto;
using Infra.Entities;// Adjust based on your project structure
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularEcommerceApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/store
        [HttpGet("get-all")]
        public async Task<ActionResult> GetStores()
        {
            //dynamic storeList = await _context.Stores.AsNoTracking().Include(s => s.StoreSnaps).ToListAsync();
            var storeList = await _context.Stores
                                 .AsNoTracking()
                                 .Include(s => s.StoreSnaps)
                                 .Select(s => new StoreDto
                                 {
                                     StoreId = s.StoreId,
                                     StoreName = s.StoreName,
                                     Description = s.Description,
                                     OwnerId = s.OwnerId,
                                     Owner = null, // You can map owner if needed
                                     StoreSnaps = s.StoreSnaps.Select(sn => new StoreSnapDto
                                     {
                                         StoreSnapId = sn.StoreSnapId,
                                         ImageUrl = sn.ImageUrl,
                                         StoreId = sn.StoreId,
                                         Store = null, // You can avoid circular references by leaving this null
                                         Products = null // Map products if needed
                                     }).ToList()
                                 }) 
                                 .ToListAsync();
            return Ok(JsonConvert.SerializeObject(storeList));
        }

        // GET: api/store/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _context.Stores
                .Include(s => s.StoreSnaps)
                .ThenInclude(ss => ss.Products)
                .FirstOrDefaultAsync(s => s.StoreId == id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        // POST: api/store
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStore), new { id = store.StoreId }, store);
        }

        // Additional actions (PUT, DELETE) can be added here
    }
}

