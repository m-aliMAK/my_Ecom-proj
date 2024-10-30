using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    internal class Tables
    {
        public class StoreOwner
        {
            //    [Key]
            //    public int StoreOwnerId { get; set; }

            //    [Required]
            //    public string FullName { get; set; }

            //    [Required, EmailAddress]
            //    public string Email { get; set; }

            //    public string PhoneNumber { get; set; }

            //    // Navigation property
            //    public ICollection<Store> Stores { get; set; }
            //}

            //public class Store
            //{
            //    [Key]
            //    public int StoreId { get; set; }

            //    [Required]
            //    public string StoreName { get; set; }

            //    public string Address { get; set; }

            //    public string Description { get; set; }

            //    // Foreign Key
            //    public int StoreOwnerId { get; set; }

            //    // Navigation property
            //    [ForeignKey("StoreOwnerId")]
            //    public StoreOwner StoreOwner { get; set; }

            //    public ICollection<Snap> Snaps { get; set; }
            //    public ICollection<Product> Products { get; set; }
            //}

            //public class Snap
            //{
            //    [Key]
            //    public int SnapId { get; set; }

            //    [Required]
            //    public string SnapImageUrl { get; set; } // URL for the snap image

            //    // Foreign Key
            //    public int StoreId { get; set; }

            //    // Navigation property
            //    [ForeignKey("StoreId")]
            //    public Store Store { get; set; }

            //    public ICollection<Product> Products { get; set; } // Products that are tagged in this snap
            //                                                       //public string FilePath { get; set; }
            //}

            //public class Product
            //{
            //    [Key]
            //    public int ProductId { get; set; }

            //    [Required]
            //    public string ProductName { get; set; }

            //    public string Description { get; set; }

            //    [Required]
            //    public decimal Price { get; set; }

            //    public string ProductImageUrl { get; set; } // URL for product image

            //    // Foreign Keys
            //    public int StoreId { get; set; }
            //    public int? SnapId { get; set; } // Optional: A product might not be linked to a snap

            //    // Navigation properties
            //    [ForeignKey("StoreId")]
            //    public Store Store { get; set; }

            //    [ForeignKey("SnapId")]
            //    public Snap Snap { get; set; }
            //    public int ProductQuantity { get; set; }
            //}

            //public class Cart
            //{
            //    [Key]
            //    public int CartId { get; set; }

            //    [Required]
            //    public string UserId { get; set; } // User's unique ID, for tracking the cart per user

            //    // Foreign Key
            //    public int ProductId { get; set; }

            //    // Navigation property
            //    [ForeignKey("ProductId")]
            //    public Product Product { get; set; }

            //    [Required]
            //    public int Quantity { get; set; }

            //    public decimal TotalPrice => Quantity * Product.Price; // Computed total price
        }
    }
}
