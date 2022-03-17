using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Domain.Entities;

namespace BravaPharm.OrderManagement.Application.Interfaces.Persistence
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(Guid categoryId);
    }
}
