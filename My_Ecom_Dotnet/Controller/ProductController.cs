using Infra.Data;
using Infra.Dto;
using Infra.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace AngularEcommerceApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _environment;

        public ProductController(ApplicationDbContext context, IImageService imageService, IProductService productService, IWebHostEnvironment environment)
        {
            _context = context;
            _imageService = imageService;
            _productService = productService;
            _environment = environment;
        }

[HttpGet("get-all-products")]
public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts()
{
    var products = await _context.Products.ToListAsync();
    if (!products.Any())
        return NotFound("No products found.");

    var productDtos = products.Select(product => new ProductResponseDto
    {
        ProductName = product.ProductName,
        Description = product.Description,
        Price = product.Price,
        ImageUrl = product.ImageUrl.Split(',').ToList() 
        //ImageUrl = product.ImageUrl?.Split(',') ?? new string[0]
    }).ToList();

    return Ok(productDtos);
}





        //this is correct code 
        //[HttpGet("get-all-products")]
        //public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts()
        //{
        //    // Retrieve all products from the database
        //    var products = await _context.Products.ToListAsync();

        //    // Manually map each product to the DTO and split the ImageUrl string
        //    var productDtos = new List<ProductResponseDto>();

        //    foreach (var product in products)
        //    {
        //        var dto = new ProductResponseDto
        //        {
        //            ProductName = product.ProductName,
        //            Description = product.Description,
        //            Price = product.Price,
        //            Images = product.ImageUrl?.Split(',')
        //        };

        //        productDtos.Add(dto);
        //    }

        //    return Ok(productDtos);
        //}

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto productDto)
        {
            var imageUrls = new List<string>();

            // Iterate over each image file, save, and get URL
            foreach (var image in productDto.Images)
            {
                if (image.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    var imageUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
                    imageUrls.Add(imageUrl); // Add each image URL to the list
                }
            }

            // Create Product entity with images
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageUrl = string.Join(",", imageUrls)
            };

            // Save product in the database using the service layer
            var result = await _productService.AddProductAsync(product);
            if (result != null)
            {
                return Ok(new { message = "Product added successfully!" });
            }

            return BadRequest("Failed to add product");
            //var product = new Product
            //{
            //    // Assuming ProductDto and Product have similar properties
            //    ProductName = productDto.ProductName,
            //    Price = productDto.Price,
            //    Description = productDto.Description,
            //    //ImageUrl = productDto.Image.ToString()
            //    // Map other properties as needed
            //};


            //// Save product in the database
            //var result = await _productService.AddProductAsync(product);
            //        if (result != null)
            //        {
            //            return Ok(new { message = "Product added successfully!" });
            //        }

            //return BadRequest("Failed to add product");
        }

        [HttpPost("upload")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UploadImage([FromForm]  List<IFormFile> productImage)
        {
            if (productImage == null || productImage.Count == 0)
                return BadRequest("Image not provided");

            // List to store URLs of saved images to return to the client.
            var imageUrls = new List<string>();

            // Iterates over each image in the list.
            foreach (var image in productImage)
            {
                // Ensures that the image has content (non-zero length).
                if (image.Length > 0)
                {
                    // Generates a unique filename using a GUID and preserves the original file extension.
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    // Combines the environment's root path with the "uploads" folder and the filename.
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

                    // Saves the image to the specified path on the server.
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    // Creates a URL for the saved image to allow the client to access it.
                    var imageUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
                    imageUrls.Add(imageUrl); // Adds the URL to the list of image URLs.
                }
            }

            // Returns a response with the list of image URLs.
            return Ok(imageUrls);
        }
    }

    
}
