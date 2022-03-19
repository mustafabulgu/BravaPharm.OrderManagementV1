using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BravaPharm.OrderManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
       

        public CategoryRepository(BravaPharmDbContext bravaPharmDbContext) : base(bravaPharmDbContext)
        {
           
        }

        public async Task<Category> GetCategoryWithProductsAsync(Guid categoryId)
        {
           return await _bravaPharmDbContext.Categories.Include(c=>c.Products).FirstOrDefaultAsync (c=>c.CategoryId == categoryId);
        }

        public Task<bool> IsUniqueCategory(string name)
        {
            var categoryExists = _bravaPharmDbContext.Categories.Any(c => c.Name == name);
            return Task.FromResult(!categoryExists);
        }
    }
}
