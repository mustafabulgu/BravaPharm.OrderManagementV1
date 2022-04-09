using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaPharm.OrderManagement.App.ViewModels
{
    public class CategoryDetailViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryProductViewModel> Products { get; set; }
    }
}
