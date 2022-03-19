using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Domain.Entities;

namespace BravaPharm.OrderManagement.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(BravaPharmDbContext bravaPharmDbContext) : base(bravaPharmDbContext)
        {
        }

        public Task<bool> IsProductUniqueForCategory(string productName, Guid categoryId)
        {
           var productExists =  _bravaPharmDbContext.Products
                .Any(p => p.ProductName == productName && p.CategoryId == categoryId);
            return Task.FromResult(!productExists);
        }
    }
}
