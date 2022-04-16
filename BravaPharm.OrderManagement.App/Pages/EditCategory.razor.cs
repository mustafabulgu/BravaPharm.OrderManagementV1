using System;
using System.Collections.Generic;

using BravaPharm.OrderManagement.App.Contracts;
using BravaPharm.OrderManagement.App.Services;
using BravaPharm.OrderManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BravaPharm.OrderManagement.App.Pages
{
    public partial class EditCategory
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public CategorySimpleViewModel CategoryToUpsert { get; set; } = new CategorySimpleViewModel();
        
        [Parameter]
        public string CategoryId { get; set; }
        public string Message { get; private set; }
       

        protected override async Task OnInitializedAsync()
        {
            
           if (Guid.TryParse(CategoryId, out var categoryId))
            {
                CategoryToUpsert = (await CategoryDataService.GetAllCategories()).First(c=>c.CategoryId==categoryId);
            }
        }
        protected async void HandleValidSubmit()
        {
            ApiResponse<Guid> apiResponse;
            if (CategoryToUpsert.CategoryId != Guid.Empty)
            {
                apiResponse = await CategoryDataService.UpdateCategory(CategoryToUpsert);
            }
            else
            {
                apiResponse = await CategoryDataService.AddCategory(CategoryToUpsert);
            }
             
            if(apiResponse.Success)
            {
                Message = "Category created/updated successfully.";
                NavigationManager.NavigateTo("/categorylist");
            }
            else
            {
                Message = apiResponse.Message;
            }
        }
        protected async Task HandleDeleteAsync()
        {
            await CategoryDataService.DeleteCategory(CategoryToUpsert.CategoryId);
            NavigationManager.NavigateTo("/categorylist");
        }
    }
}
