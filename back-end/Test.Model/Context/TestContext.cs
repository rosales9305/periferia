using Microsoft.EntityFrameworkCore;
using Test.Model.Entities;

namespace Test.Model.Context
{
    public class TestContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public TestContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
