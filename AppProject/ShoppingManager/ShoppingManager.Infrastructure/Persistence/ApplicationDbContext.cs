using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShoppingManager.Domain.Entities;

namespace ShoppingManager.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ListElement> ListElements { get; set; }
        public DbSet<ListAccess> ListAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ListAccess>()
                .HasKey(la => new { la.ShoppingListId, la.UserId });

            modelBuilder.Entity<ListAccess>()
                .HasOne(la => la.ShoppingList)
                .WithMany(sl => sl.ListAccesses)
                .HasForeignKey(la => la.ShoppingListId);

            modelBuilder.Entity<ShoppingList>()
                .HasMany(sl => sl.ListElements)
                .WithOne(le => le.ShoppingList)
                .HasForeignKey(le => le.ShoppingListId);

            modelBuilder.Entity<ListElement>()
                .HasOne(le => le.Product)
                .WithMany(p => p.ListElements)
                .HasForeignKey(le => le.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.CategoryId);

        }
    }
}
