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
    }
}
