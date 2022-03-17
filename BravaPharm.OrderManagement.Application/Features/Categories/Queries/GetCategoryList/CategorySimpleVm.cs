using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryList
{
    public class CategorySimpleVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
