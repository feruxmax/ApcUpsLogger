using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApcUpsLogger.DataAccess
{
    public class ApcUpsLoggerDbContext : DbContext
    {
        public ApcUpsLoggerDbContext(DbContextOptions<ApcUpsLoggerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

        }

        public virtual DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
