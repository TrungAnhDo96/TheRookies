using Microsoft.EntityFrameworkCore;
using RK_A11.Entities;

namespace RK_A11.DB
{
    public class InventoryContext : DbContext
    {
        private static readonly Category[] InitCategories = new Category[3] {
            new Category() { CategoryId = 1, CategoryName = "Consumables" },
            new Category() { CategoryId = 2, CategoryName = "Electronics" },
            new Category() { CategoryId = 3, CategoryName = "Decorations" }
        };

        private static readonly Product[] InitProducts = new Product[6] {
            new Product() { ProductId = 1, ProductName = "Pizza", Manufacture = "Pizza Hut", CategoryId = 1},
            new Product() { ProductId = 2, ProductName = "Airpods", Manufacture = "Apple", CategoryId = 2 },
            new Product() { ProductId = 3, ProductName = "Red bull Energy Drink", Manufacture = "Red Bull", CategoryId = 1},
            new Product() { ProductId = 4, ProductName = "Curtain", Manufacture = "IKEA", CategoryId = 3},
            new Product() { ProductId = 5, ProductName = "Bose QC 35 II", Manufacture = "Bose", CategoryId = 2},
            new Product() { ProductId = 6, ProductName = "Wall Clock", Manufacture = "Seiko", CategoryId = 3},
        };

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ProductSchema");

            //build columns and relationships
            modelBuilder.Entity<Product>()
                        .HasOne<Category>(c => c.Category)
                        .WithMany(p => p.Products)
                        .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Category>().ToTable("CategoryInfo").HasData(InitCategories);
            modelBuilder.Entity<Product>().ToTable("ProductInfo").HasData(InitProducts);
        }
    }
}