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

        public Category GetCategoryWithProducts(Guid categoryId)
        {
           return  _bravaPharmDbContext.Categories.Include(c=>c.Products).FirstOrDefault(c=>c.CategoryId == categoryId);
        }
    }
}
