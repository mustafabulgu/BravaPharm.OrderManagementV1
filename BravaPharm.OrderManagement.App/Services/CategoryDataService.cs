using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.App.Contracts;
using BravaPharm.OrderManagement.App.ViewModels;

namespace BravaPharm.OrderManagement.App.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;

        public CategoryDataService(IMapper mapper, IClient client)
        {
            _mapper = mapper;
            _client = client;
        }
        public async Task<ApiResponse<Guid>> AddCategory(CategorySimpleViewModel category)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var guid = await _client.AddCategoryAsync(_mapper.Map<CreateCategoryCommand>(category));
                response.Data = guid;
                response.Success = true;
                response.Message = "Category created successfully";

            }
            catch (ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task DeleteCategory(Guid id)
        {
            return _client.DeleteCategoryAsync(id);
        }

        public async Task<List<CategorySimpleViewModel>> GetAllCategories()
        {
            var categories = await _client.GetAllCategoriesAsync();
            return _mapper.Map<List<CategorySimpleViewModel>>(categories);
        }

        public async Task<CategoryDetailViewModel> GetCategory(Guid id)
        {
            var category = await _client.GetCategoryDetailsAsync(id);
            return _mapper.Map<CategoryDetailViewModel>(category);
        }

        public async Task<ApiResponse<Guid>> UpdateCategory(CategorySimpleViewModel category)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                await _client.UpdateCategoryAsync(_mapper.Map<UpdateCategoryCommand>(category));
                response.Message = "Update successful";
                response.Success = true;
                response.Data = category.CategoryId;
            }
            catch(ApiException ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
