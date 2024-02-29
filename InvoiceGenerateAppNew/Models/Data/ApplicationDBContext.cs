using InvoiceGenerateAppNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenerateAppNew.Data
{
    public class ApplicationDBContext : DbContext
	{
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)  //Adding Configurations to DbContext Base Class
        {
            
        }

		//Entities (DB Tables)
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceMaster> InvoiceMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)   //Using default function to insert data
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Keyboard", ProductPrice = 2500, StoreQuantity = 50 },
                new Product { ProductId = 2, ProductName = "Mouse", ProductPrice = 1000, StoreQuantity = 100 },
                new Product { ProductId = 3, ProductName = "Monitor", ProductPrice = 40000, StoreQuantity = 28 },
                new Product { ProductId = 4, ProductName = "UPS", ProductPrice = 12500, StoreQuantity = 35 },
                new Product { ProductId = 5, ProductName = "SSD", ProductPrice = 8000, StoreQuantity = 20 },
                new Product { ProductId = 6, ProductName = "Pen-Drive", ProductPrice = 4000, StoreQuantity = 30 }
                );
        }

    }
}
