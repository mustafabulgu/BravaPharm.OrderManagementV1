using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.App.Services;
using BravaPharm.OrderManagement.App.ViewModels;

namespace BravaPharm.OrderManagement.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategorySimpleViewModel>> GetAllCategories();
        Task<CategoryDetailViewModel> GetCategory(Guid id);
        Task<ApiResponse<Guid>> AddCategory(CategorySimpleViewModel category);
        Task<ApiResponse<Guid>> UpdateCategory(CategorySimpleViewModel category);
        Task DeleteCategory(Guid id);
    }
}
