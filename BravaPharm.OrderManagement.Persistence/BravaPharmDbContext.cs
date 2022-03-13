using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BravaPharm.OrderManagement.Persistence
{
    public class BravaPharmDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BravaPharmDbContext(DbContextOptions<BravaPharmDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BravaPharmDbContext).Assembly);
            
           
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>() )
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "mbulgu";
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "mbulgu";
                }
            }
            return base.SaveChangesAsync(cancellation);
        }
    }
}
