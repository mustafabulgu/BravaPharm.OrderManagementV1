using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Domain.Entities;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class CategoryDetailVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryProductVm> Products { get; set; }
    }
}
