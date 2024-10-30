using Infra.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreSnap> StoreSnaps { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        

        //    protected override void OnModelCreating(ModelBuilder builder)
        //    {
        //        base.OnModelCreating(builder);

        //        builder.Entity<Store>()
        //            .HasOne(s => s.Owner)
        //            .WithMany(u => u.Stores)
        //            .HasForeignKey(s => s.OwnerId);

        //        builder.Entity<StoreSnap>()
        //            .HasOne(ss => ss.Store)
        //            .WithMany(s => s.StoreSnaps)
        //            .HasForeignKey(ss => ss.StoreId);

        //        builder.Entity<Product>()
        //            .HasOne(p => p.StoreSnap)
        //            .WithMany(ss => ss.Products)
        //            .HasForeignKey(p => p.StoreSnapId);

        //        builder.Entity<CartItem>()
        //            .HasOne(ci => ci.Product)
        //            .WithMany(p => p.CartItems)
        //            .HasForeignKey(ci => ci.ProductId)
        //            .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.NoAction)

        //        builder.Entity<CartItem>()
        //            .HasOne(ci => ci.Cart)
        //            .WithMany(c => c.CartItems)
        //            .HasForeignKey(ci => ci.CartId)
        //            .OnDelete(DeleteBehavior.Cascade); // Keep cascading delete if you want




        //        // Seed data for AspNetUsers table
        //        // Seed data for AspNetUsers table
        //        builder.Entity<ApplicationUser>().HasData(
        //    new ApplicationUser { Id = "1", UserName = "customer1", Email = "customer1@example.com", FirstName = "Alice", LastName = "Wonder" },
        //    new ApplicationUser { Id = "2", UserName = "customer2", Email = "customer2@example.com", FirstName = "Bob", LastName = "Builder" },
        //    new ApplicationUser { Id = "3", UserName = "customer3", Email = "customer3@example.com", FirstName = "Charlie", LastName = "Chaplin" }
        //);

        //        // Seed data for Stores table
        //        builder.Entity<Store>().HasData(
        //            new Store { StoreId = 1, StoreName = "Store One", Description = "First Store", OwnerId = "1" },
        //            new Store { StoreId = 2, StoreName = "Store Two", Description = "Second Store", OwnerId = "2" },
        //            new Store { StoreId = 3, StoreName = "Store Three", Description = "Third Store", OwnerId = "3" },
        //            new Store { StoreId = 4, StoreName = "Store Four", Description = "Fourth Store", OwnerId = "1" },
        //            new Store { StoreId = 5, StoreName = "Store Five", Description = "Fifth Store", OwnerId = "2" }
        //        );

        //        // Seed data for StoreSnap table
        //        builder.Entity<StoreSnap>().HasData(
        //            new StoreSnap { StoreSnapId = 1, StoreId = 1, ImageUrl = "https://example.com/store1snap1.jpg" },
        //            new StoreSnap { StoreSnapId = 2, StoreId = 1, ImageUrl = "https://example.com/store1snap2.jpg" },
        //            new StoreSnap { StoreSnapId = 3, StoreId = 2, ImageUrl = "https://example.com/store2snap1.jpg" },
        //            new StoreSnap { StoreSnapId = 4, StoreId = 3, ImageUrl = "https://example.com/store3snap1.jpg" },
        //            new StoreSnap { StoreSnapId = 5, StoreId = 4, ImageUrl = "https://example.com/store4snap1.jpg" }
        //        );

        //        // Seed data for Product table
        //        builder.Entity<Product>().HasData(
        //            new Product { ProductId = 1, ProductName = "Product A", Description = "First Product", Price = 10.99M, Quantity = 100, StoreSnapId = 1 },
        //            new Product { ProductId = 2, ProductName = "Product B", Description = "Second Product", Price = 15.50M, Quantity = 50, StoreSnapId = 1 },
        //            new Product { ProductId = 3, ProductName = "Product C", Description = "Third Product", Price = 20.00M, Quantity = 150, StoreSnapId = 2 },
        //            new Product { ProductId = 4, ProductName = "Product D", Description = "Fourth Product", Price = 30.99M, Quantity = 200, StoreSnapId = 3 },
        //            new Product { ProductId = 5, ProductName = "Product E", Description = "Fifth Product", Price = 40.99M, Quantity = 75, StoreSnapId = 4 }
        //        );

        //        // Seed data for Cart table
        //        builder.Entity<Cart>().HasData(
        //    new Cart { CartId = 1, CustomerId = "1" },
        //    new Cart { CartId = 2, CustomerId = "2" },
        //    new Cart { CartId = 3, CustomerId = "3" }
        //);

        //        // Seed data for CartItem table
        //        builder.Entity<CartItem>().HasData(
        //            new CartItem { CartItemId = 1, CartId = 1, ProductId = 1, Quantity = 2 },
        //            new CartItem { CartItemId = 2, CartId = 1, ProductId = 3, Quantity = 1 },
        //            new CartItem { CartItemId = 3, CartId = 2, ProductId = 2, Quantity = 3 },
        //            new CartItem { CartItemId = 4, CartId = 2, ProductId = 5, Quantity = 2 },
        //            new CartItem { CartItemId = 5, CartId = 3, ProductId = 4, Quantity = 1 }
        //        );
        //    }
        //}
    }
}
