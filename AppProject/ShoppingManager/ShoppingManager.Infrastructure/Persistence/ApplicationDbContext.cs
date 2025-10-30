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
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<ListElement> ListElements { get; set; }
        public DbSet<ListAccess> ListAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // List Access ma klucz złożony (UserId + ShoppingListId)
            modelBuilder.Entity<ListAccess>()
                .HasKey(la => new { la.ShoppingListId, la.UserId });

            modelBuilder.Entity<ListAccess>()
                .HasOne<ShoppingList>()
                .WithMany(sl => sl.ListAccesses)
                .HasForeignKey(la => la.ShoppingListId);

            // NIE OGARNIAM TEGO
            modelBuilder.Entity<ShoppingList>()
                .HasMany(sl => sl.ListElements)
                .WithOne(le => le.ShoppingList)
                .HasForeignKey(le => le.ShoppingListId);

        }
    }
}
